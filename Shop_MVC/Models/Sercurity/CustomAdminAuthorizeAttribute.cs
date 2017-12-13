using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_MVC.Models.Sercurity
{
    public class CustomAdminAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (HttpContext.Current == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                         new System.Web.Routing.RouteValueDictionary(
                          new
                          {
                              Controller = "adLogin",
                              Action = "Index",
                              ReturnUrl = filterContext.HttpContext.Request.RawUrl
                          }));
                return;
            }
            var acc = (Acount)HttpContext.Current.Session["Login"];

            if (acc == null)
            {
                //  filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Account", Action = "Index" }));
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new
                        {
                            Controller = "adLogin",
                            Action = "Index",
                            ReturnUrl = filterContext.HttpContext.Request.RawUrl
                        }));
            }
            else
            {
                CustomPrincipal cp = new CustomPrincipal(acc);
                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { Controller = "adLogin", Action = "Index" }));
                }
            }
        }
    }
}