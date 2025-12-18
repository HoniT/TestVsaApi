using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;
using Microsoft.AspNetCore.Mvc;

namespace src.Features.Employees.Add
{
    public class AddEmployeeEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/employees", async (
                CreateEmployeeDto employeeDto,
                AddEmployeeHandler handler) =>
            {
                var result = await handler.HandleAsync(employeeDto);
                return Results.Ok(result);
            })
            .WithName("AddEmployee")
            .WithTags("Employees");
        }
    }
}