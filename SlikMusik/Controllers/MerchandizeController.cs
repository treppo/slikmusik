using System.Web.Mvc;
using SlikMusik.Domain;

namespace SlikMusik.Controllers
{
    public class MerchandizeController : Controller
    {
        private readonly UserRequestListener userRequestListener = new EfStoreRegistry(new EfDbContext());

        public ActionResult Create(int storeId)
        {
            return View(new Merchandize() {StoreId = storeId});
        }

        [HttpPost]
        public ActionResult Create(Merchandize merch)
        {
            if (ModelState.IsValid)
            {
                userRequestListener.AddToStore(merch);
                return RedirectToAction("Visit", "Store", new {id = merch.StoreId});
            }
            return View();
        }
    }
}
