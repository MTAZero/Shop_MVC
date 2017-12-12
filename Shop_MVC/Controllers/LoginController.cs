using Shop_MVC.Models.Sercurity;
using Shop_MVC.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult DangXuat()
        {
            Session["Login"] = null;
            return RedirectToAction("Index");
        }

        #region Hàm trả về Json
        [HttpPost]
        public JsonResult DangNhap(string Email, string MatKhau)
        {
            Acount tk = new TaiKhoanService().DangNhap(Email, MatKhau);
            bool ok = true;

            if (tk == null)
                ok = false;
            else
                Session["Login"] = tk;

            return Json(
                    new
                    {
                        ok = ok
                    }
                );
        }
        #endregion
    }
}