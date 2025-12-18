using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Features.Employees;

namespace src.Features
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
        : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}