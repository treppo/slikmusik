namespace SlikMusik.Core
{
    public interface StoreUserRequestListener
    {
        void AddToInventory(Merchandize merch);
        Merchandize GetMerchandize(int merchandizeId);
        void AddToShoppingCart(ShoppingCart shoppingCart, int merchandizeId);
    }
}