using System.Linq;

namespace SlikMusik.Domain
{
    public class EfStoreRegistry : StoreRegistry
    {
        readonly EfDbContext context = new EfDbContext();

        public void Add(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
        }

        public Store Visit(int id)
        {
            return context.Stores.First(store => store.Id == id);
        }
    }
}