using Shop_MVC.Models.Db;
using Shop_MVC.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        #region Json result
        [HttpPost]
        public JsonResult ListProduct()
        {

            MatHangService mh = new MatHangService();
            List<MATHANG> ds = mh.getAll().ToList();

            return
                Json(
                    new
                    {
                        status = "true",
                        ListProduct = ds.ToList()
                            .Select(p => new {
                                ID = p.ID,
                                TEN = p.TEN,
                                GIA = p.GIA,
                                KHUYENMAI = p.KHUYENMAI,
                                ANH = new ANHSPService().getAll().Where(z=>z.ID == p.ID).FirstOrDefault().SRC
                            })
                            .ToList()
                    }
                );
        }
        #endregion
    }
}