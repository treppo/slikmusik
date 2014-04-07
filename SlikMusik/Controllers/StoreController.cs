using System.Web.Mvc;
using SlikMusik.Domain;

namespace SlikMusik.Controllers
{
    public class StoreController : Controller
    {
        private readonly UserRequestListener userRequestListener;
        private EfStoreRegistry storeRegistry;

        public StoreController()
        {
            storeRegistry = new EfStoreRegistry();
            userRequestListener = new Marketplace(storeRegistry);
        }

        public ActionResult Visit(int id)
        {
            return View();
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
            return View();
        }
    }
}