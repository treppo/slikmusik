using System.Linq;

namespace SlikMusik.Domain
{
    public class StoreClerk : StoreUserRequestListener
    {
        private readonly StoreRegistry registry;

        public StoreClerk(StoreRegistry registry)
        {
            this.registry = registry;
        }

        public void Add(Merchandize merch)
        {
            var store = registry.FindStore(merch.StoreId);
            store.Merchandize.Add(merch);
            registry.Change(store);
        }

        public Merchandize GetMerchandize(int storeId, int merchandizeId)
        {
            var store = registry.FindStore(storeId);
            return store.Merchandize.First(merch => merch.Id == merchandizeId);
        }
    }
}