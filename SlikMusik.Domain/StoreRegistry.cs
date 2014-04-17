using System.Linq;

namespace SlikMusik.Domain
{
    public interface StoreRegistry
    {
        void OpenUp(Store store);
        Store FindStore(int id);
        IQueryable<Store> ListAllStores();
        void Change(Store store);
    }
}
