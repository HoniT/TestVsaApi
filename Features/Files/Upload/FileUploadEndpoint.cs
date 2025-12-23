using MediatR;
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
                IFormFileCollection files,
                HttpContext context,
                IMediator mediator) =>
            {
                var command = new FileUploadCommand(files, context);
                var result = await mediator.Send(command);
                return result;
            })
            .DisableAntiforgery()
            .WithName("MultiUpload")
            .WithTags("Files");
        }
    }
}
