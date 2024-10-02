using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EAMDbcontext:DbContext
    {
        public EAMDbcontext(DbContextOptions<EAMDbcontext>options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Attendance)
                .WithOne(a => a.Employee)
                .HasForeignKey<Attendance>(a => a.EmployeeID);
        }
    }
}
