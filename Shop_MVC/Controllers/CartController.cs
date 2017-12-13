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
    public class CartController : Controller
    {
        // GET: Cart
        [CustomAuthorizeAttribute(Roles = "User , Admin")]
        public ActionResult Index()
        {
            return View();
        }

        #region Trả về Json
        [HttpPost]
        public JsonResult DanhSach()
        {
            Cart giohang = (Cart)Session["Cart"];
            float TongTien = ((float)giohang.ListItem.Sum(p => p.THANHTIEN));
            float VAT = TongTien / 10;

            return
                Json(
                    new
                    {
                        Carts = giohang.ListItem
                                .Select(p=>new
                                {
                                    ID = new MatHangService().getAll().Where(z => z.ID == p.MATHANGID).FirstOrDefault().ID,
                                    Ma = new MatHangService().getAll().Where(z => z.ID == p.MATHANGID).FirstOrDefault().MA,
                                    Ten = new MatHangService().getAll().Where(z=>z.ID == p.MATHANGID).FirstOrDefault().TEN,
                                    Anh = new ANHSPService().getAll().Where(z => z.MATHANGID == p.MATHANGID).FirstOrDefault().SRC,
                                    Gia = ((double) new MatHangService().getAll().Where(z => z.ID == p.MATHANGID).FirstOrDefault().GIA).ToString("N0"),
                                    SoLuong = p.SOLUONG,
                                    ThanhTien = ((double) p.THANHTIEN).ToString("N0")
                                }).ToList(),
                        TongTien = TongTien.ToString("N0"),
                        VAT = (TongTien/10).ToString("N0"),
                        PhiVanChuyen = 0.ToString("N0"),
                        ThanhTien = (TongTien + VAT).ToString("N0")
                    }
                );
        }

        [HttpPost]
        public JsonResult ThemHang(int id)
        {
            Cart giohang = (Cart)Session["Cart"];
            giohang.Add(id);

            return
                Json(
                    new
                    {
                        status = "ok"
                    }
                );
        }

        [HttpPost]
        public JsonResult GiamHang(int id)
        {
            Cart giohang = (Cart)Session["Cart"];
            giohang.Sub(id);

            return
                Json(
                    new
                    {
                        status = "ok"
                    }
                );
        }

        [HttpPost]
        public JsonResult XoaHang(int id)
        {
            Cart giohang = (Cart)Session["Cart"];
            giohang.Delete(id);

            return
                Json(
                    new
                    {
                        status = "ok"
                    }
                );
        }

        [HttpPost]
        public JsonResult SoLuong()
        {
            Cart giohang = (Cart)Session["Cart"];
            int soluong = giohang.ListItem.Sum(p => p.SOLUONG).Value;

            return
                Json(
                    new
                    {
                        SoLuong = soluong
                    }
                );
        }
        #endregion
    }
}