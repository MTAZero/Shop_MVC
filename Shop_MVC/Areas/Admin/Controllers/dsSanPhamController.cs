using Shop_MVC.Models.Service;
using System;
using System.Collections.Generic;
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

        #region Json action
        [HttpPost]
        public JsonResult XoaSanPham(int id)
        {
            string err = "";
            MatHangService sv = new MatHangService();
            bool ok = sv.Delete(id, ref err);

            string tinnhan = "";
            if (!ok)
                tinnhan = err; //"Sản phẩm đã được chứa trong các hóa đơn nên không thể xóa";

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