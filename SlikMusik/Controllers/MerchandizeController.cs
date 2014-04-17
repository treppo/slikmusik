using System.Web.Mvc;
using SlikMusik.Domain;

namespace SlikMusik.Controllers
{
    public class MerchandizeController : Controller
    {
        private readonly StoreUserRequestListener userRequestListener = new StoreClerk(new EfStoreRegistry(new EfDbContext()));

        public ActionResult Create(int storeId)
        {
            return View(new Merchandize() {StoreId = storeId});
        }

        [HttpPost]
        public ActionResult Create(Merchandize merch)
        {
            if (ModelState.IsValid)
            {
                userRequestListener.Add(merch);
                return RedirectToAction("Visit", "Store", new {id = merch.StoreId});
            }
            return View();
        }

        public ActionResult Show(int storeId, int id)
         {
            var merch = userRequestListener.GetMerchandize(storeId, id);
            return View(merch);
        }
    }
}
