using System.Web.Mvc;
using SlikMusik.Domain;

namespace SlikMusik.Controllers
{
    public class StoreController : Controller
    {
        private readonly UserRequestListener userRequestListener = new EfStoreRegistry(new EfDbContext());

        public ActionResult Visit(int id)
        {
            var store = userRequestListener.FindStore(id);
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
                userRequestListener.OpenUp(store);

                return RedirectToAction("Visit", new {id = store.Id});
            }

            return View();
        }

        public ActionResult List()
        {
            var stores = userRequestListener.ListAllStores();
            return View(stores);
        }
    }
}