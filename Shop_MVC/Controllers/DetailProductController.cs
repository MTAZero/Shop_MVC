using Shop_MVC.Models.Db;
using Shop_MVC.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_MVC.Controllers
{
    public class DetailProductController : Controller
    {
        // GET: DetailProduct
        public ActionResult Index(int id)
        {
            string err = "";
            MATHANG a = new MatHangService().Find(id, ref err);

            if (a == null) return View("er404");

            return View(a);
        }

        #region Các hàm trả về Json 

        [HttpPost]
        public JsonResult ThongTinSanPham(int id)
        {
            MATHANG mh = new MatHangService().getAll().Where(p => p.ID == id).FirstOrDefault();

            return
                Json(
                    new
                    {
                        status = "ok",
                        Anh = new ANHSPService().getAll().Where(p => p.MATHANGID == mh.ID).FirstOrDefault().SRC,
                        NhaSanXuat = new NHASANXUATService().getAll().Where(p => p.ID == mh.NHASANXUATID).FirstOrDefault().TEN,
                        SanPhamLienQuan = new MatHangService().getAll().Take(3)
                            .Select(z => new
                            {
                                ID = z.ID,
                                TEN = z.TEN,
                                GIA = z.GIA,
                                KHUYENMAI = z.KHUYENMAI,
                                ANH = new ANHSPService().getAll().Where(k => k.MATHANGID == z.ID).FirstOrDefault().SRC
                            }).ToList(),
                        SanPhamKhuyenDung = new MatHangService().getAll().Take(6)
                            .Select(z => new
                            {
                                ID = z.ID,
                                TEN = z.TEN,
                                GIA = z.GIA,
                                KHUYENMAI = z.KHUYENMAI,
                                ANH = new ANHSPService().getAll().Where(k => k.MATHANGID == z.ID).FirstOrDefault().SRC
                            }).ToList(),
                    }
                );
        }

        #endregion
    }
}