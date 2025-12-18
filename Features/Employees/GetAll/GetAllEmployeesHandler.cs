using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace src.Features.Employees.GetAll
{
    public class GetAllEmployeesHandler
    {
        private readonly ApplicationDbContext _context;
        public GetAllEmployeesHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllEmployeesResponse> HandleAsync(
        CancellationToken ct)
        {
            var employees = await _context.Employees
                .AsNoTracking()
                .Select(e => new Employee
                {
                    Id = e.Id,
                    Name = e.Name,
                    LastName = e.LastName,
                    Position = e.Position ,
                    Salary = e.Salary
                })
                .ToListAsync(ct);

            return new GetAllEmployeesResponse(employees);
        }
    }
}