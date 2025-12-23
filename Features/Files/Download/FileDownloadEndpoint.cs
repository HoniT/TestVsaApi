using MediatR;
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
                IMediator mediator) =>
            {
                var command = new FileDownloadCommand(fileName);
                var result = mediator.Send(command);
                return result;
            })
            .WithName("DownloadFile")
            .WithTags("Files");
        }
    }
}
