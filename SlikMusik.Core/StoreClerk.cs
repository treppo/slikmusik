namespace SlikMusik.Core
{
    public class StoreClerk : StoreUserRequestListener
    {
        private readonly Inventory inventory;

        public StoreClerk(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public void AddToInventory(Merchandize merch)
        {
            inventory.Add(merch);
        }

        public Merchandize GetMerchandize(int merchandizeId)
        {
            return inventory.Retrieve(merchandizeId);
        }

        public void AddToShoppingCart(ShoppingCart shoppingCart, int merchandizeId)
        {
            shoppingCart.Add(GetMerchandize(merchandizeId));
        }
    }
}