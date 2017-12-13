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
    public class CartController : Controller
    {
        // GET: Cart
        [CustomAuthorizeAttribute(Roles = "User , Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorizeAttribute(Roles = "User , Admin")]
        public ActionResult ThanhToan()
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
                                .Select(p => new
                                {
                                    ID = new MatHangService().getAll().Where(z => z.ID == p.MATHANGID).FirstOrDefault().ID,
                                    Ma = new MatHangService().getAll().Where(z => z.ID == p.MATHANGID).FirstOrDefault().MA,
                                    Ten = new MatHangService().getAll().Where(z => z.ID == p.MATHANGID).FirstOrDefault().TEN,
                                    Anh = new ANHSPService().getAll().Where(z => z.MATHANGID == p.MATHANGID).FirstOrDefault().SRC,
                                    Gia = ((double)new MatHangService().getAll().Where(z => z.ID == p.MATHANGID).FirstOrDefault().GIA).ToString("N0"),
                                    SoLuong = p.SOLUONG,
                                    ThanhTien = ((double)p.THANHTIEN).ToString("N0")
                                }).ToList(),
                        TongTien = TongTien.ToString("N0"),
                        VAT = (TongTien / 10).ToString("N0"),
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

        [HttpPost]
        public JsonResult ThanhToan(string SDT, string diachi, string yeucau)
        {
            Acount acount = (Acount)Session["Login"];
            DONHANG a = new DONHANG();
            a.MA = 0;
            a.DIACHI = diachi;
            a.YEUCAUGIAOHANG = yeucau;
            a.SDT = SDT;
            a.TAIKHOANID = acount.ID;
            a.TRANGTHAI = 0; //  Đang giao hàng

            Shop_MVC_Context db = new Shop_MVC_Context();
            db.DONHANGs.Add(a);
            try
            {
                db.SaveChanges();
                Cart cart = (Cart)Session["Cart"];

                string err = "";
                a.TONGTIEN = 0;
                foreach (CHITIETDONHANG item in cart.ListItem)
                {
                    item.DONHANGID = a.ID;
                    a.TONGTIEN += new MatHangService().Find((int) item.MATHANGID, ref err).GIA * item.SOLUONG;
                    db.CHITIETDONHANGs.Add(item);
                }

                a.TONGTIEN += a.TONGTIEN / 10; /// VAT
                db.SaveChanges();

                
                cart.ListItem.Clear();
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    ok = false,
                    exception = ex.Message
                });
            }
                
            return Json(new
            {
                ok = true,
                exception = ""
            }
            );
        }
        #endregion
    }
}