using MediatR;
using Microsoft.AspNetCore.Http;

namespace src.Features.Files.Upload
{
    public class FileUploadHandler
        : IRequestHandler<FileUploadCommand, IResult>
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadHandler(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<IResult> Handle(
            FileUploadCommand request,
            CancellationToken ct)
        {
            IFormFileCollection files = request.files;
            if (files == null || files.Count == 0)
                return Results.BadRequest("No files uploaded");

            var uploadDir = Path.Combine(
                _env.WebRootPath,
                "Resources",
                "Files"
            );

            Directory.CreateDirectory(uploadDir);

            var uploadedFiles = new List<object>();

            foreach (var file in files)
            {
                if (file.Length == 0)
                    continue;

                var filePath = Path.Combine(uploadDir, file.FileName);

                if (File.Exists(filePath))
                    return Results.BadRequest("File already exists: " + file.FileName);

                await using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                var downloadUrl =
                    $"{request.context.Request.Scheme}://" +
                    $"{request.context.Request.Host}/files/{file.FileName}";

                uploadedFiles.Add(new
                {
                    fileName = file.FileName,
                    size = file.Length,
                    downloadUrl
                });
            }

            return Results.Ok(new { files = uploadedFiles });
        }
    }
}
