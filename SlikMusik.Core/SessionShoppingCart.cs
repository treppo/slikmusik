using System.Collections.Generic;

namespace SlikMusik.Core
{
    public class SessionShoppingCart : ShoppingCart
    {
        private readonly List<Merchandize> content = new List<Merchandize>();

        public IEnumerable<Merchandize> Content
        {
            get { return content; }
        }

        public void Remove(int id)
        {
            content.RemoveAll(merch => merch.Id == id);
        }

        public static ShoppingCart From(ShoppingCart cart)
        {
            return cart ?? new SessionShoppingCart();
        }

        public void Add(Merchandize merch)
        {
            content.Add(merch);
        }
    }
}