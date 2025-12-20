using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace src.Features.Employees.Delete
{
    public class DeleteEmployeeHandler
        : IRequestHandler<DeleteEmployeeCommand, DeleteEmployeeResponse>
    {
        private readonly ApplicationDbContext _context;
        public DeleteEmployeeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteEmployeeResponse> Handle(
            DeleteEmployeeCommand request,
            CancellationToken ct)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == request.id, ct);

            if (employee is null)
                throw new KeyNotFoundException($"Employee {request.id} not found");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(ct);

            return new DeleteEmployeeResponse(employee);
        }
    }
}