using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Features.Files.Upload;

namespace src.Features.Files.Upload
{
    public static class FileUploadEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/multiupload", async (
                [FromForm] IFormFileCollection files,
                FileUploadHandler handler,
                HttpContext context) =>
            {
                return await handler.HandleAsync(files, context);
            })
            .DisableAntiforgery()
            .WithName("MultiUpload")
            .WithTags("Files");
        }
    }
}
