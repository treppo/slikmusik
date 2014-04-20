using System.Data.Common;
using System.Data.Entity;

namespace SlikMusik.Core
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() { }
        public EfDbContext(DbConnection connection) : base(connection, true)  { }
        public IDbSet<Store> Stores { get; set; }
        public IDbSet<Merchandize> Merchandize { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .Ignore(store => store.InventorySize)
                .Property(store => store.UserId)
                .IsRequired();

            modelBuilder.Entity<Store>()
                .Property(store => store.Name)
                .IsRequired();

            modelBuilder.Entity<Store>()
                .HasMany(store => store.Inventory)
                .WithRequired()
                .HasForeignKey(merchandize => merchandize.StoreId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Merchandize>()
                .Property(merch => merch.Name)
                .IsRequired();
        }
    }
}