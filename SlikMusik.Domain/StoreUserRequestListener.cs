namespace SlikMusik.Domain
{
    public interface StoreUserRequestListener
    {
        void Add(Merchandize merch);
        Merchandize GetMerchandize(int storeId, int merchandizeId);
    }
}