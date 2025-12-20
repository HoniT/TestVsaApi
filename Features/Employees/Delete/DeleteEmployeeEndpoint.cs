using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace src.Features.Employees.Delete
{
    public class DeleteEmployeeEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/employees", async (
                int id,
                IMediator mediator) =>
            {
                var command = new DeleteEmployeeCommand(id);
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("DeleteEmployee")
            .WithTags("Employees");
        }
    }
}