using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Features.Employees.Delete
{
    public record DeleteEmployeeResponse(
        Employee Employee
    );
}