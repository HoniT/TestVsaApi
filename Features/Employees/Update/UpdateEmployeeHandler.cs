using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using src.Features.Employees;

namespace src.Features.Employees.Update
{
    public class UpdateEmployeeHandler
        : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeResponse>
    {
        private readonly ApplicationDbContext _context;
        public UpdateEmployeeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateEmployeeResponse> Handle(
            UpdateEmployeeCommand request,
            CancellationToken cancellationToken)
        {
            var employeeModel = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == request.id, cancellationToken);

            if (employeeModel is null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            var employeeDto = request.dto;

            employeeModel.Name = employeeDto.Name;
            employeeModel.LastName = employeeDto.LastName;
            employeeModel.Position = employeeDto.Position;
            employeeModel.Salary = employeeDto.Salary;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateEmployeeResponse(employeeModel);
        }

    }
}