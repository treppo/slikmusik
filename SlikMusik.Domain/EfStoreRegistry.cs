namespace SlikMusik.Domain
{
    public class EfStoreRegistry : StoreRegistry
    {
        EfDbContext context = new EfDbContext();

        public void Add(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
        }
    }
}