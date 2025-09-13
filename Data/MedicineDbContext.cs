namespace GraphQLPOC.Data;
// Data/MedicineDbContext.cs
using Microsoft.EntityFrameworkCore;
using GraphQLPOC.Model;


public class MedicineDbContext : DbContext
{
    public MedicineDbContext(DbContextOptions<MedicineDbContext> options) : base(options)
    {
    }

    public DbSet<Medicine> Medicines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Medicine entity
        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Company).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Price);
        });

        // Seed initial data
        modelBuilder.Entity<Medicine>().HasData(
            new Medicine
            {
                Id = 1,
                Name = "Paracetamol 500mg",
                Company = "ABC Pharma",
                Price = 25.50m,
                Quantity = 100,
                ExpiryDate = new DateTime(2026, 12, 31),
                CreatedDate = DateTime.UtcNow
            },
            new Medicine
            {
                Id = 2,
                Name = "Aspirin 100mg",
                Company = "XYZ Medical",
                Price = 15.75m,
                Quantity = 150,
                ExpiryDate = new DateTime(2025, 6, 30),
                CreatedDate = DateTime.UtcNow
            }
        );
    }
}
