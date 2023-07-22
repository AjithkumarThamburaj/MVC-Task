using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvctask111.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("EmployeeConnection")
        {

        }
        public DbSet<Employee> EmployeesTable { get; set; }
    }
}