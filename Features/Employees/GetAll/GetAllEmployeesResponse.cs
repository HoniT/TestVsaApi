using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Features.Employees.GetAll
{
    // GetAllEmployeesResponse.cs
    public record GetAllEmployeesResponse(
        IReadOnlyList<Employee> Employees
    );

}