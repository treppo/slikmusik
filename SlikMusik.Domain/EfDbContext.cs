using System.Data.Common;
using System.Data.Entity;

namespace SlikMusik.Domain
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() { }
        public EfDbContext(DbConnection connection) : base(connection, true)  { }
        public IDbSet<Store> Stores { get; set; }
        public IDbSet<Merchandize> Merchandizes { get; set; }
    }
}