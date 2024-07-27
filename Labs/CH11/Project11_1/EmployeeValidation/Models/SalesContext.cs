using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeValidation.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options) { }

        public DbSet<Sales> Sales { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Joyce",
                    LastName = "Valdez",
                    DOB = new DateTime(1995, 1, 1),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerId = 0, //No manager
                },
                 new Employee
                 {
                     EmployeeId = 2,
                     FirstName = "Joanna",
                     LastName = "Gains",
                     DOB = new DateTime(1984, 1, 1),
                     DateOfHire = new DateTime(2020, 1, 1),
                     ManagerId = 1, 
                 },
                  new Employee
                  {
                      EmployeeId = 3,
                      FirstName = "Chip",
                      LastName = "Gains",
                      DOB = new DateTime(1980, 1, 10),
                      DateOfHire = new DateTime(2021, 1, 1),
                      ManagerId = 1, 
                  }
                );

            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesId = 1,
                    Quarter = 4,
                    Year = 2021,
                    Amount = 23456,
                    EmployeeId= 2
                },

                 new Sales
                 {
                     SalesId = 2,
                     Quarter = 1,
                     Year = 2022,
                     Amount = 34567,
                     EmployeeId = 2
                 },

                  new Sales
                  {
                      SalesId = 3,
                      Quarter = 4,
                      Year = 2021,
                      Amount = 19876,
                      EmployeeId = 3
                  },

                   new Sales
                   {
                       SalesId = 4,
                       Quarter = 1,
                       Year = 2022,
                       Amount = 31009,
                       EmployeeId = 3
                   }

                );
        }
    }
}
