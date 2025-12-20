using MediatR;

namespace src.Features.Employees.Add
{
    public record AddEmployeeCommand(CreateEmployeeDto Employee)
        : IRequest<AddEmployeeResponse>;
}
