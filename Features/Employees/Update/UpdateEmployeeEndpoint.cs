using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using MediatR;

namespace src.Features.Employees.Update
{
    public class UpdateEmployeeEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/employees", async (
                int id,
                UpdateEmployeeDto dto,
                IMediator mediator) =>
            {
                var command = new UpdateEmployeeCommand(id, dto);
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("UpdateEmployee")
            .WithTags("Employees");
        }
    }
}