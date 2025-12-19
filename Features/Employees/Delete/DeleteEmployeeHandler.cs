using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace src.Features.Employees.Delete
{
    public class DeleteEmployeeHandler
    {
        private readonly ApplicationDbContext _context;
        public DeleteEmployeeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteEmployeeResponse?> HandleAsync(int id)
        {
            var employeeModel = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(employeeModel == null)
            {
                return null;
            }
            _context.Remove(employeeModel);
            await _context.SaveChangesAsync();

            return new DeleteEmployeeResponse(employeeModel);
        }
    }
}