using System.Data.Entity;

namespace SlikMusik.Domain
{
    public class EfDbContext : DbContext
    {
        public IDbSet<Store> Stores { get; set; }
    }
}