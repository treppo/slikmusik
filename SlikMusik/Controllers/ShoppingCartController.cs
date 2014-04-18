using System.Web.Mvc;
using SlikMusik.Domain;

namespace SlikMusik.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreUserRequestListener userRequestListener =
            new StoreClerk(new EfInventory(new EfDbContext()));

        public ActionResult Add(int id)
        {
            userRequestListener.AddToShoppingCart(shoppingCart, id);
            return RedirectToAction("View");
        }

        public ActionResult View()
        {
            throw new System.NotImplementedException();
        }

        private ShoppingCart shoppingCart
        {
            get
            {
                var cart = (ShoppingCart) Session["ShoppingCart"];

                if (cart == null)
                {
                    cart = new ShoppingCart();
                    Session["ShoppingCart"] = cart;
                }

                return cart;
            }
        }
    }
}