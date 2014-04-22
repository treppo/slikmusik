using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SlikMusik.Core;

namespace SlikMusik.Authorization
{
    public class StoreOwnerAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (IsNotStoreOwner(filterContext))
            {
                filterContext.Result = new HttpStatusCodeResult(403);
            }
        }

        private bool IsNotStoreOwner(AuthorizationContext filterContext)
        {
            return
                !(filterContext.HttpContext.Request.IsAuthenticated &&
                  CurrentStoreFrom(StoreId(filterContext))
                      .HasOwner(CurrentUserId));
        }

        private static string CurrentUserId
        {
            get { return HttpContext.Current.User.Identity.GetUserId(); }
        }

        private static string StoreId(AuthorizationContext filterContext)
        {
            return
                (filterContext.HttpContext.Request.RequestContext.RouteData.Values["id"] ??
                 filterContext.HttpContext.Request.RequestContext.RouteData.Values["storeId"]) as string;
        }

        private static Store CurrentStoreFrom(string storeId)
        {
            var registry = EfStoreRegistry.Create();
            return registry.FindStore(Int32.Parse(storeId));
        }
    }
}