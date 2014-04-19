using System.Web.Mvc;
using SlikMusik.Core;

namespace SlikMusik.Controllers
{
    public class MerchandizeController : Controller
    {
        private readonly StoreUserRequestListener userRequestListener =
            new StoreClerk(new EfInventory(new EfDbContext()));

        public ActionResult Create(int storeId)
        {
            return View(new Merchandize() {StoreId = storeId});
        }

        [HttpPost]
        public ActionResult Create(Merchandize merch)
        {
            if (ModelState.IsValid)
            {
                userRequestListener.AddToInventory(merch);
                return RedirectToAction("Visit", "Store", new {id = merch.StoreId});
            }
            return View();
        }

        public ActionResult Show(int storeId, int id)
        {
            return View(userRequestListener.GetMerchandize(id));
        }
    }
}