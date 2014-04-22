using System.Collections.Generic;
using System.Linq;

namespace SlikMusik.Core
{
    public class EfStoreRegistry : StoreRegistry
    {
        readonly EfDbContext context;
        private static EfStoreRegistry instance;

        public static EfStoreRegistry Create()
        {
            return Create(new EfDbContext());
        }

        public static EfStoreRegistry Create(EfDbContext context)
        {
            instance = instance ?? new EfStoreRegistry(context);
            return instance;
        }

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