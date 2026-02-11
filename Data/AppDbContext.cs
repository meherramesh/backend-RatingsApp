using Microsoft.EntityFrameworkCore;
using RatingsApp.Models;

namespace RatingsApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<QualityPerformance> QualityPerformances { get; set; }
        public DbSet<DeliveryPerformance> DeliveryPerformances { get; set; }
        public DbSet<CostReduction> CostReductions { get; set; }
        public DbSet<PaymentTerms> PaymentTerms { get; set; }
        public DbSet<ResponsePerformance> ResponsePerformances { get; set; }
        public DbSet<OverallRating> OverallRatings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.QualityPerformance)
                .WithOne()
                .HasForeignKey<QualityPerformance>(q => q.SupplierId);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.DeliveryPerformance)
                .WithOne()
                .HasForeignKey<DeliveryPerformance>(d => d.SupplierId);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.CostReduction)
                .WithOne()
                .HasForeignKey<CostReduction>(c => c.SupplierId);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.PaymentTerms)
                .WithOne()
                .HasForeignKey<PaymentTerms>(p => p.SupplierId);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.ResponsePerformance)
                .WithOne()
                .HasForeignKey<ResponsePerformance>(r => r.SupplierId);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.OverallRating)
                .WithOne()
                .HasForeignKey<OverallRating>(o => o.SupplierId);
        }
    }
}
