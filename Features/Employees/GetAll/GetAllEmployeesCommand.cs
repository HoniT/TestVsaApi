using MediatR;

namespace src.Features.Employees.GetAll
{
    public record GetAllEmployeesCommand()
        : IRequest<GetAllEmployeesResponse>;
}
