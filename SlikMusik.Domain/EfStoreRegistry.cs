using System.Linq;

namespace SlikMusik.Domain
{
    public class EfStoreRegistry : StoreRegistry, UserRequestListener
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
            return context.Stores.First(store => store.Id == id);
        }

        public IQueryable<Store> ListAllStores()
        {
            return context.Stores;
        }

        public void Change(Store store)
        {
            context.SaveChanges();
        }

        public void AddToStore(Merchandize merch)
        {
            var store = FindStore(merch.StoreId);
            store.Merchandizes.Add(merch);
            context.SaveChanges();
        }
    }
}