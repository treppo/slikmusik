using System.Collections.Generic;
using System.Linq;

namespace SlikMusik.Core
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

        public IEnumerable<Store> ListAllStores()
        {
            return context.Stores.OrderBy(store => store.Name);
        }

        public void Change(Store store)
        {
            context.SaveChanges();
        }
    }
}