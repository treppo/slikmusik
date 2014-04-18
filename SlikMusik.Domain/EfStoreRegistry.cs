using System.Collections;
using System.Linq;

namespace SlikMusik.Domain
{
    public class EfStoreRegistry : StoreRegistry
    {
        readonly EfDbContext context;

        public EfStoreRegistry(EfDbContext context)
        {
            this.context = context;
        }

        public void OpenUp(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
        }

        public Store FindStore(int id)
        {
            return context.Stores.Find(id);
        }

        public IList ListAllStores()
        {
            return context.Stores.ToList();
        }

        public void Change(Store store)
        {
            context.SaveChanges();
        }
    }
}