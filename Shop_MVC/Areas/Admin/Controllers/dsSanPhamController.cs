using Shop_MVC.Models.Db;
using Shop_MVC.Models.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_MVC.Areas.Admin.Controllers
{
    public class dsSanPhamController : Controller
    {
        // GET: Admin/dsSanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemSanPham()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemSanPham(string TenSanPham, string MaSanPham, int NhaSanXuatID, int LoaiSanPhamID, double GiaSanPham, string ChiTietSanPham, HttpPostedFileBase Anh)
        {
            ViewBag.ThongBao = "Thành công";

            /// thêm mặt hàng
            MATHANG mh = new MATHANG();
            mh.TEN = TenSanPham;
            mh.MA = MaSanPham;
            mh.NHASANXUATID = NhaSanXuatID;
            mh.LOAISANPHAMID = LoaiSanPhamID;
            mh.GIA = GiaSanPham;
            mh.CHITET = ChiTietSanPham;
            mh.KHUYENMAI = 0;

            Shop_MVC_Context db = new Shop_MVC_Context();
            db.MATHANGs.Add(mh);

            try
            {
                /// thêm ảnh sản phẩm
                db.SaveChanges();
                if (Anh.ContentLength > 0)
                {
                    var fileName = "product" + mh.ID + ".png";

                    string j = Path.Combine(
                        Server.MapPath("~/Content/Client/images/product/"), fileName);
                    Anh.SaveAs(j);

                    ANHSP a = new ANHSP();

                    a.SRC = "/Content/Client/images/product/" + fileName;
                    a.MATHANGID = mh.ID;
                    db.ANHSPs.Add(a);
                    db.SaveChanges();
                }

            }
            catch
            {
                ViewBag.ThongBao = "Thêm sản phẩm không thành công";
            }

            return View("TrangThaiThemSanPham");
        }

        #region Json action
        [HttpPost]
        public JsonResult XoaSanPham(int id)
        {
            string err = "";
            MatHangService sv = new MatHangService();
            bool ok = sv.Delete(id, ref err);

            string tinnhan = "";
            if (!ok)
                tinnhan = "Sản phẩm đã được chứa trong các hóa đơn nên không thể xóa";

            return Json(
                new
                {
                    status = ok,
                    tinnhan = tinnhan
                }
                );
        }

        
        #endregion
    }
}