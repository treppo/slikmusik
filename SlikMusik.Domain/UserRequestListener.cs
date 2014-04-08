
namespace SlikMusik.Domain
{
    public interface UserRequestListener
    {
        void OpenUp(Store store);
        Store Visit(int id);
    }
}
