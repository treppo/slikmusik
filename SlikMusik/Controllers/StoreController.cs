﻿using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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

        [Authorize]
        public ActionResult OpenUp()
        {
            return View(new Store());
        }

        [HttpPost]
        [Authorize]
        public ActionResult OpenUp(Store store)
        {
            if (ModelState.IsValid)
            {
                store.UserId = HttpContext.User.Identity.GetUserId();
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