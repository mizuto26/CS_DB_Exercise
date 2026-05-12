using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<ItemEntity> Items { get; set; } = null!;
    public DbSet<ItemCategoryEntity> ItemCategories { get; set; } = null!;
    public DbSet<ItemStockEntity> ItemStocks { get; set; } = null!;
    public DbSet<SalesEntity> Sales { get; set; } = null!;
    public DbSet<SalesDetailEntity> SalesDetails { get; set; } = null!;
    public DbSet<DepartmentEntity> Departments { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Host=172.31.23.251;Database=cs_db_exercise;Username=appuser;Password=training;";

        optionsBuilder
            .UseNpgsql(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemEntity>()
            .HasOne(itemEntity => itemEntity.Category)
            .WithMany(itemEntitycategory => itemEntitycategory.Items)
            .HasForeignKey(itemEntity => itemEntity.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SalesDetailEntity>()
            .HasOne(salesDetailEntity => salesDetailEntity.Item)
            .WithMany()
            .HasForeignKey(salesDetailEntity => salesDetailEntity.ItemId);
    }
}
