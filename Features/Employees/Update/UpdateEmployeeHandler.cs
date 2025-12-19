using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Features.Employees;

namespace src.Features.Employees.Update
{
    public class UpdateEmployeeHandler
    {
        private readonly ApplicationDbContext _context;
        public UpdateEmployeeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateEmployeeResponse?> HandleAsync(int id, UpdateEmployeeDto employeeDto)
        {
            var employeeModel = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(employeeModel == null)
            {
                return null;
            }

            employeeModel.Name = employeeDto.Name;
            employeeModel.LastName = employeeDto.LastName;
            employeeModel.Position = employeeDto.Position;
            employeeModel.Salary = employeeDto.Salary;
            
            await _context.SaveChangesAsync();

            return new UpdateEmployeeResponse(employeeModel);
        }
    }
}