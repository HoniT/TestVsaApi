using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Features.Employees.Delete
{
    public class DeleteEmployeeEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/employees", async (
                int id,
                DeleteEmployeeHandler handler) =>
            {
                var result = await handler.HandleAsync(id);
                return Results.Ok(result);
            })
            .WithName("DeleteEmployee")
            .WithTags("Employees");
        }
    }
}