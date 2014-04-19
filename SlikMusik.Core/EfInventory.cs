namespace SlikMusik.Core
{
    public class EfInventory : Inventory
    {
        private readonly EfDbContext context;

        public EfInventory(EfDbContext context)
        {
            this.context = context;
        }

        public void Add(Merchandize merch)
        {
            context.Merchandize.Add(merch);
            context.SaveChanges();
        }

        public Merchandize Retrieve(int id)
        {
            return context.Merchandize.Find(id);
        }
    }
}