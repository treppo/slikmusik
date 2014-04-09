using System.Linq;

namespace SlikMusik.Domain
{
    public interface UserRequestListener
    {
        void OpenUp(Store store);
        Store FindStore(int id);
        IQueryable<Store> ListAllStores();
    }
}
