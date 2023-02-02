using Microsoft.EntityFrameworkCore;
namespace MVC_T2.Models
{
    public class CompanyDBcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5KKQVT9\\SS17;Initial Catalog=Company;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOnProject>().HasKey("EmpSSN", "projNum");
            modelBuilder.Entity<DepartmentLocation>().HasKey("DeptNumber", "Location");
            modelBuilder.Entity<Employee>().HasOne(s => s.Supervisor).WithMany(s => s.Employees);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DepartmentLocation> DepartmentLocation { get; set; }
        public DbSet<WorkOnProject> WorksOnProjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

    }
}
