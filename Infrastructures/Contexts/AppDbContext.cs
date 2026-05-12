using Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Infrastructures.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<DepartmentEntity> Departments { get; set; } = null!;
    public DbSet<EmployeeEntity> Employees { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString =
        "Host=localhost;Database=cs_db_exercise;Username=postgres;Password=training;";

        optionsBuilder
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();
    }
}