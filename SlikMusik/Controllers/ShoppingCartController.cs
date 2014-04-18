using System.Web.Mvc;
using SlikMusik.Domain;

namespace SlikMusik.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly StoreUserRequestListener userRequestListener =
            new StoreClerk(new EfInventory(new EfDbContext()));

        [HttpPost]
        public ActionResult Add(int id)
        {
            userRequestListener.AddToShoppingCart(ShoppingCart, id);
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            return View(ShoppingCart);
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