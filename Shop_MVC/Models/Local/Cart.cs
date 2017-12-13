using Shop_MVC.Models.Db;
using Shop_MVC.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_MVC.Models.Local
{
    public class Cart
    {
        public List<CHITIETDONHANG> ListItem = new List<CHITIETDONHANG>();

        public void Add(int id)
        {
            string err = "";
            CHITIETDONHANG a = ListItem.Where(p => p.MATHANGID == id).FirstOrDefault();
            if (a == null)
            {
                CHITIETDONHANG z = new CHITIETDONHANG();
                z.MATHANGID = id;
                z.SOLUONG = 1;
                z.THANHTIEN = new MatHangService().Find(id, ref err).GIA * z.SOLUONG;

                ListItem.Add(z);
                return;
            }

            a.SOLUONG++;
            
            a.THANHTIEN = new MatHangService().Find(id, ref err).GIA * a.SOLUONG;
        }

        public void Sub(int id)
        {
            CHITIETDONHANG a = ListItem.Where(p => p.MATHANGID == id).FirstOrDefault();
            if (a == null) return;

            a.SOLUONG--;
            string err = "";
            a.THANHTIEN = new MatHangService().Find(id, ref err).GIA * a.SOLUONG;

            if (a.SOLUONG <= 0) ListItem.Remove(a);
        }

        public void Delete(int id)
        {
            CHITIETDONHANG a = ListItem.Where(p => p.MATHANGID == id).FirstOrDefault();
            if (a == null) return;

            ListItem.Remove(a);
        }
    }
}