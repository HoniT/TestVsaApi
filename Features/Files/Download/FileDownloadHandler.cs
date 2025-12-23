using MediatR;
using Microsoft.AspNetCore.Http;

namespace src.Features.Files.Download
{
    public class FileDownloadHandler
        : IRequestHandler<FileDownloadCommand, IResult>
    {
        private readonly IWebHostEnvironment _env;

        public FileDownloadHandler(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<IResult> Handle(
            FileDownloadCommand request,
            CancellationToken ct)
        {
            var uploadDir = Path.Combine(
                _env.WebRootPath,
                "Resources",
                "Files"
            );

            var path = Path.Combine(uploadDir, request.fileName);

            if (!File.Exists(path))
                return Results.NotFound();

            return Results.File(
                path,
                "application/octet-stream",
                request.fileName
            );
        }

    }
}
