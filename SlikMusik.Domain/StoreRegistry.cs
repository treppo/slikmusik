using System.Collections;

namespace SlikMusik.Domain
{
    public interface StoreRegistry
    {
        void OpenUp(Store store);
        Store FindStore(int id);
        IList ListAllStores();
        void Change(Store store);
    }
}