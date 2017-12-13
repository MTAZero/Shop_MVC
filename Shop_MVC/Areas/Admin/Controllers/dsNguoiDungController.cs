using Shop_MVC.Models.Sercurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_MVC.Areas.Admin.Controllers
{
    public class dsNguoiDungController : Controller
    {
        // GET: Admin/dsNguoiDung
        [CustomAdminAuthorizeAttribute(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}