using System.Web.Mvc;
using SlikMusik.Core;

namespace SlikMusik.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreUserRequestListener userRequestListener =
            new StoreClerk(new EfInventory(new EfDbContext()));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int id)
        {
            userRequestListener.AddToShoppingCart(ShoppingCart, id);
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            return View(ShoppingCart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            ShoppingCart.Remove(id);
            return RedirectToAction("Show");
        }

        private ShoppingCart ShoppingCart
        {
            get
            {
                var cart = SessionShoppingCart.From((ShoppingCart) Session["ShoppingCart"]);
                Session["ShoppingCart"] = cart;
                return cart;
            }
        }
    }
}