namespace SlikMusik.Domain
{
    public interface ShoppingUserRequestListener
    {
        void AddMerchandizeToShoppingCart(int merchandizeid, int shoppingCartId);
    }
}