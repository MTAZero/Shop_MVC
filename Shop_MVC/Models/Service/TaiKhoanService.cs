using Shop_MVC.Models.Db;
using Shop_MVC.Models.Sercurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_MVC.Models.Service
{
    public class TaiKhoanService
    {
        private Shop_MVC_Context dataContext = new Shop_MVC_Context();

        public Acount DangNhap(string Email, string MatKhau)
        {
            int cnt = dataContext.TAIKHOANs.Where(p => p.EMAIL == Email && p.MATKHAU == MatKhau).ToList().Count;

            if (cnt == 0)
            {
                return null;
            }

            TAIKHOAN tk = dataContext.TAIKHOANs.Where(p => p.EMAIL == Email && p.MATKHAU == MatKhau).FirstOrDefault();
            Acount ac = new Acount();
            ac.ID = tk.ID;
            ac.Name = tk.TEN;
            ac.Email = tk.EMAIL;

            if (tk.QUYEN == 1) ac.Role = "Admin"; else ac.Role = "User";

            return ac;
        }

        public TAIKHOAN Add(TAIKHOAN entity, ref string err)
        {
            try
            {
                dataContext.TAIKHOANs.Add(entity);
                dataContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return new TAIKHOAN();
            }
        }

        public bool Delete(int id, ref string err)
        {
            try
            {
                TAIKHOAN entity = dataContext.TAIKHOANs.Find(id);
                dataContext.TAIKHOANs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool Delete(TAIKHOAN entity, ref string err)
        {
            try
            {
                dataContext.TAIKHOANs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public TAIKHOAN Find(int id, ref string err)
        {
            TAIKHOAN entity = dataContext.TAIKHOANs.Find(id);
            if (entity == null)
            {
                err = "Không tìm thấy";
                return null;
            }

            return entity;
        }

        public IList<TAIKHOAN> getAll()
        {
            return dataContext.TAIKHOANs.ToList();
        }

        public bool Save(ref string err)
        {
            try
            {
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool Update(TAIKHOAN entity, ref string err)
        {
            try
            {
                TAIKHOAN tgz = dataContext.TAIKHOANs.Find(entity.ID);

                tgz.TEN = entity.TEN;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}