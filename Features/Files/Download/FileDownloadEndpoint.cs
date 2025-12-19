using Microsoft.AspNetCore.Http;
using src.Features.Files.Download;

namespace src.Features.Files.Download
{
    public static class FileDownloadEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/download/{fileName}", (
                string fileName,
                FileDownloadHandler handler) =>
            {
                return handler.Handle(fileName);
            })
            .WithName("DownloadFile")
            .WithTags("Files");
        }
    }
}
