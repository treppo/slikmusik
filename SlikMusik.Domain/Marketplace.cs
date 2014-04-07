namespace SlikMusik.Domain
{
    public class Marketplace : UserRequestListener
    {
        private readonly StoreRegistry storeRegistry;

        public Marketplace(StoreRegistry storeRegistry)
        {
            this.storeRegistry = storeRegistry;
        }

        public void OpenUp(Store store)
        {
            storeRegistry.Add(store);
        }
    }
}