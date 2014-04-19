using System.Collections.Generic;

namespace SlikMusik.Core
{
    public interface StoreRegistry
    {
        void OpenUp(Store store);
        Store FindStore(int id);
        IList<Store> ListAllStores();
        void Change(Store store);
    }
}