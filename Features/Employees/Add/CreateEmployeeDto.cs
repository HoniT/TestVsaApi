using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace src.Features.Employees.Add
{
    public class CreateEmployeeDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Enter a valid name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Enter a valid lastname")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Enter a valid position")]
        public string Position { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
    }
}