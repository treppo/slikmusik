using System.Collections.Generic;

namespace SlikMusik.Core
{
    public interface StoreRegistry
    {
        void OpenUp(Store store);
        Store FindStore(int id);
        IEnumerable<Store> ListAllStores();
        void Change(Store store);
    }
}