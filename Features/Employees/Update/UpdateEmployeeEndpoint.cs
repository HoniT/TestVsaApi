using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace src.Features.Employees.Update
{
    public class UpdateEmployeeEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/employees", async (
                int id,
                UpdateEmployeeDto dto,
                UpdateEmployeeHandler handler) =>
            {
                var result = await handler.HandleAsync(id, dto);
                return Results.Ok(result);
            })
            .WithName("UpdateEmployee")
            .WithTags("Employees");
        }
    }
}