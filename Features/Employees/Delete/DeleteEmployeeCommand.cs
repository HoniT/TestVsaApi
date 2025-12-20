using MediatR;

namespace src.Features.Employees.Delete
{
    public record DeleteEmployeeCommand(int id)
        : IRequest<DeleteEmployeeResponse>;
}
