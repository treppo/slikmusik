namespace SlikMusik.Domain
{
    public interface Inventory
    {
        void Add(Merchandize merch);
        Merchandize Retrieve(int id);
    }
}