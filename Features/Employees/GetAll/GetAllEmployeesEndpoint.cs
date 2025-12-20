using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace src.Features.Employees.GetAll
{
    public class GetAllEmployeesEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/employees", async (
                CancellationToken ct,
                IMediator mediator) =>
            {
                var command = new GetAllEmployeesCommand();
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("GetAllEmployees")
            .WithTags("Employees");
        }
    }
}