using System.Web.Mvc;
using SlikMusik.Core;

namespace SlikMusik.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreRegistry storeRegistry = new EfStoreRegistry(new EfDbContext());

        public ActionResult Visit(int id)
        {
            var store = storeRegistry.FindStore(id);
            return View(store);
        }

        public ActionResult OpenUp()
        {
            return View(new Store());
        }

        [HttpPost]
        public ActionResult OpenUp(Store store)
        {
            if (ModelState.IsValid)
            {
                storeRegistry.OpenUp(store);

                return RedirectToAction("Visit", new { id = store.Id});
            }

            return View();
        }

        public ActionResult List()
        {
            var stores = storeRegistry.ListAllStores();
            return View(stores);
        }

        public ActionResult Configure(int id)
        {
            var store = storeRegistry.FindStore(id);
            return View(store);
        }

        [HttpPost]
        public ActionResult Configure(Store store)
        {
            if (ModelState.IsValid)
            {
                storeRegistry.Change(store);

                return RedirectToAction("Visit", new { id = store.Id });
            }

            return View();
        }
    }
}