using Microsoft.EntityFrameworkCore;

namespace Task5_DF_CF_.Models.CodeFirst
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext(
            DbContextOptions<CodeFirstDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//عشان مشكلة الكاسكيد ديليت
        {
            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(p => p.PurchaseOrder)
                .WithMany(p => p.PurchaseOrderItems)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}