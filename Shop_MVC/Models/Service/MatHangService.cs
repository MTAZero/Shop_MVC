using Shop_MVC.Models.Db;
using Shop_MVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_MVC.Models.Service
{
    public class MatHangService : IService<MATHANG>
    {
        private Shop_MVC_Context dataContext = new Shop_MVC_Context();

        public MATHANG Add(MATHANG entity, ref string err)
        {
            try
            {
                dataContext.MATHANGs.Add(entity);
                dataContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return new MATHANG();
            }
        }

        public bool Delete(int id, ref string err)
        {
            try
            {
                ANHSP anh = dataContext.ANHSPs.Where(p => p.MATHANGID == id).FirstOrDefault();
                MATHANG entity = dataContext.MATHANGs.Find(id);
                dataContext.ANHSPs.Remove(anh);
                dataContext.MATHANGs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool Delete(MATHANG entity, ref string err)
        {
            try
            {
                dataContext.MATHANGs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public MATHANG Find(int id, ref string err)
        {
            MATHANG entity = dataContext.MATHANGs.Find(id);
            if (entity == null)
            {
                err = "Không tìm thấy";
                return null;
            }

            return entity;
        }

        public IList<MATHANG> getAll()
        {
            return dataContext.MATHANGs.ToList();
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

        public bool Update(MATHANG entity, ref string err)
        {
            try
            {
                MATHANG tgz = dataContext.MATHANGs.Find(entity.ID);

                tgz.TEN = entity.TEN;
                tgz.MA = entity.MA;
                tgz.GIA = entity.GIA;
                tgz.KHUYENMAI = entity.KHUYENMAI;
                tgz.CHITET = entity.CHITET;

                tgz.NHASANXUATID = entity.NHASANXUATID;
                tgz.LOAISANPHAMID = entity.LOAISANPHAMID;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}