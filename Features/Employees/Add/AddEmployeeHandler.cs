using MediatR;

namespace src.Features.Employees.Add
{
    public class AddEmployeeHandler
        : IRequestHandler<AddEmployeeCommand, AddEmployeeResponse>
    {
        private readonly ApplicationDbContext _context;

        public AddEmployeeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AddEmployeeResponse> Handle(
            AddEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.Employee;

            var employee = new Employee
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Position = dto.Position,
                Salary = dto.Salary
            };

            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new AddEmployeeResponse(employee);
        }
    }
}
