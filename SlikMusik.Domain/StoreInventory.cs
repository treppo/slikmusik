namespace SlikMusik.Domain
{
    public class StoreInventory : StoreUserRequestListener
    {
        private readonly StoreRegistry registry;

        public StoreInventory(StoreRegistry registry)
        {
            this.registry = registry;
        }

        public void Add(Merchandize merch)
        {
            var store = registry.FindStore(merch.StoreId);
            store.Merchandize.Add(merch);
            registry.Change(store);
        }
    }
}
