

using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Context
{
    public class CourseAgency : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = CourseAgency; Trusted_Connection = true; encrypt = false");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instuctor> Instuctors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
    }
}
