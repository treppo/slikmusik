namespace SlikMusik.Core
{
    public interface Inventory
    {
        void Add(Merchandize merch);
        Merchandize Retrieve(int id);
    }
}