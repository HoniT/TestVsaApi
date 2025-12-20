using MediatR;

namespace src.Features.Employees.Update
{
    public record UpdateEmployeeCommand(int id, UpdateEmployeeDto dto)
        : IRequest<UpdateEmployeeResponse>;
}
