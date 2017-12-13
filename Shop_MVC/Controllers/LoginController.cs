using Shop_MVC.Models.Db;
using Shop_MVC.Models.Local;
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
            Session["Cart"] = null;
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
            {
                Cart cart = new Cart();
                cart.ListItem = new List<CHITIETDONHANG>();
                Session["Cart"] = cart;
                Session["Login"] = tk;
            }

            return Json(
                    new
                    {
                        ok = ok
                    }
                );
        }

        [HttpPost]
        public JsonResult DangKy(string Email, string MatKhau, string HoTen)
        {
            bool ok = true;
            string message = "";

            ok = new TaiKhoanService().getAll().Where(p => p.EMAIL == Email).ToList().Count == 0;
            if (!ok) message = "Email đã được sử dung. Vui lòng dùng Email khác";

            if (ok)
            {
                TAIKHOAN a = new TAIKHOAN();
                a.TEN = HoTen;
                a.EMAIL = Email;
                a.MATKHAU = MatKhau;
                a.QUYEN = 0;

                string err = "";
                new TaiKhoanService().Add(a, ref err);
                Acount tk = new TaiKhoanService().DangNhap(Email, MatKhau);
                Session["Login"] = tk;
            }

            return Json(
                    new
                    {
                        status = ok,
                        message = message
                    }
                );
        }

        #endregion
    }
}