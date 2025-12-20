using MediatR;

namespace src.Features.Employees.Add
{
    public class AddEmployeeEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/employees", async (
                CreateEmployeeDto employeeDto,
                IMediator mediator) =>
            {
                var command = new AddEmployeeCommand(employeeDto);
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("AddEmployee")
            .WithTags("Employees");
        }
    }
}
