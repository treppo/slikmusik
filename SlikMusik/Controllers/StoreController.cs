using System.Web.Mvc;
using SlikMusik.Domain.Entities;

namespace SlikMusik.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store/Details/5
        public ActionResult Visit(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult OpenUp()
        {
            return View(new Store());
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult OpenUp(Store store)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
