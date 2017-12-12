using Shop_MVC.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_MVC.Models.Service
{
    public class NHASANXUATService
    {
        private Shop_MVC_Context dataContext = new Shop_MVC_Context();

        public NHASANXUAT Add(NHASANXUAT entity, ref string err)
        {
            try
            {
                dataContext.NHASANXUATs.Add(entity);
                dataContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return new NHASANXUAT();
            }
        }

        public bool Delete(int id, ref string err)
        {
            try
            {
                NHASANXUAT entity = dataContext.NHASANXUATs.Find(id);
                dataContext.NHASANXUATs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool Delete(NHASANXUAT entity, ref string err)
        {
            try
            {
                dataContext.NHASANXUATs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public NHASANXUAT Find(int id, ref string err)
        {
            NHASANXUAT entity = dataContext.NHASANXUATs.Find(id);
            if (entity == null)
            {
                err = "Không tìm thấy";
                return null;
            }

            return entity;
        }

        public IList<NHASANXUAT> getAll()
        {
            return dataContext.NHASANXUATs.ToList();
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

        public bool Update(NHASANXUAT entity, ref string err)
        {
            try
            {
                NHASANXUAT tgz = dataContext.NHASANXUATs.Find(entity.ID);

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