using CS_DB_Exercise.CS_DB_Sample.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace CS_DB_Exercise.CS_DB_Sample.Infrastructures.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<ItemEntity> Items { get; set; } = null!;
    public DbSet<ItemCategoryEntity> ItemCategories { get; set; } = null!;
    public DbSet<SalesDetailEntity> SalesDetails { get; set; } = null!;
    public DbSet<SalesEntity> Sales { get; set; } = null!;

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
        modelBuilder.Entity<ItemCategoryEntity>(entity =>
        {
            entity.ToTable("item_category");
            entity.HasKey(itemCategoryEntity => itemCategoryEntity.Id);
            entity.Property(itemCategoryEntity => itemCategoryEntity.Id).HasColumnName("id");
            entity.Property(itemCategoryEntity => itemCategoryEntity.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ItemEntity>(entity =>
        {
            entity.ToTable("item");
            entity.HasKey(itemEntity => itemEntity.Id);
            entity.Property(itemEntity => itemEntity.Id).HasColumnName("id");
            entity.Property(itemEntity => itemEntity.Name).HasColumnName("name");
            entity.Property(itemEntity => itemEntity.Price).HasColumnName("price");
            entity.Property(itemEntity => itemEntity.CategoryId).HasColumnName("category_id");

            entity.HasOne(itemEntity => itemEntity.Category)
                .WithMany(itemCategoryEntity => itemCategoryEntity.Items)
                .HasForeignKey(itemEntity => itemEntity.CategoryId);
        });

        modelBuilder.Entity<ItemStockEntity>(entity =>
        {
            entity.ToTable("item_stock");
            entity.HasKey(itemStockEntity => itemStockEntity.Id);
            entity.Property(itemStockEntity => itemStockEntity.Id).HasColumnName("id");
            entity.Property(itemStockEntity => itemStockEntity.ItemId).HasColumnName("item_id");
            entity.Property(itemStockEntity => itemStockEntity.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<SalesDetailEntity>(entity =>
        {
            entity.ToTable("sales_detail");
            entity.HasKey(salesDetailEntity => salesDetailEntity.Id);
            entity.Property(salesDetailEntity => salesDetailEntity.Id).HasColumnName("id");
            entity.Property(salesDetailEntity => salesDetailEntity.SalesId).HasColumnName("sales_id");
            entity.Property(salesDetailEntity => salesDetailEntity.Quantity).HasColumnName("quantity");
            entity.Property(salesDetailEntity => salesDetailEntity.Subtotal).HasColumnName("subtotal");
            entity.Property(salesDetailEntity => salesDetailEntity.ItemId).HasColumnName("item_id");

            entity.HasOne(salesDetailEntity => salesDetailEntity.Item)
                .WithMany()
                .HasForeignKey(salesDetailEntity => salesDetailEntity.ItemId);
        });

        modelBuilder.Entity<SalesEntity>(entity =>
        {
            entity.ToTable("sales");
            entity.HasKey(salesEntity => salesEntity.Id);
            entity.Property(salesEntity => salesEntity.Id).HasColumnName("id");
            entity.Property(salesEntity => salesEntity.SalesDate).HasColumnName("sales_date");
            entity.Property(salesEntity => salesEntity.Total).HasColumnName("total");
            entity.Property(salesEntity => salesEntity.AccountId).HasColumnName("account_id");
        });
    }
}
