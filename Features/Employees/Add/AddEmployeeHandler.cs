using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Employee;

namespace src.Features.Employees.Add
{
    public class AddEmployeeHandler
    {
        private readonly ApplicationDbContext _context;
        public AddEmployeeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AddEmployeeResponse> HandleAsync(CreateEmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                LastName = employeeDto.LastName,
                Position = employeeDto.Position,
                Salary = employeeDto.Salary
            };
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return new AddEmployeeResponse(employee);
        }
    }
}