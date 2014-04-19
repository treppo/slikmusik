﻿using System.Data.Common;
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
                .HasMany(store => store.Inventory)
                .WithRequired()
                .HasForeignKey(merchandize => merchandize.StoreId);
        }
    }
}