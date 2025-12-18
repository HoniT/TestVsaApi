using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Features.Employees.GetAll
{
    public class GetAllEmployeesEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/employees", async (
                GetAllEmployeesHandler handler,
                CancellationToken ct) =>
            {
                var result = await handler.HandleAsync(ct);
                return Results.Ok(result);
            })
            .WithName("GetAllEmployees")
            .WithTags("Employees");
        }
    }
}