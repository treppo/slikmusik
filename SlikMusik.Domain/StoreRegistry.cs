
namespace SlikMusik.Domain
{
    public interface StoreRegistry
    {
        void Add(Store store);
        Store Visit(int id);
    }
}
