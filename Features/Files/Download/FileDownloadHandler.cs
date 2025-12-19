using Microsoft.AspNetCore.Http;

namespace src.Features.Files.Download
{
    public class FileDownloadHandler
    {
        private readonly IWebHostEnvironment _env;

        public FileDownloadHandler(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IResult Handle(string fileName)
        {
            var uploadDir = Path.Combine(
                _env.WebRootPath,
                "Resources",
                "Files"
            );

            var path = Path.Combine(uploadDir, fileName);

            if (!File.Exists(path))
                return Results.NotFound();

            return Results.File(
                path,
                "application/octet-stream",
                fileName
            );
        }
    }
}
