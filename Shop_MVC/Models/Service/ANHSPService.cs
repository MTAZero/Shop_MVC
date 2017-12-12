using Shop_MVC.Models.Db;
using Shop_MVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_MVC.Models.Service
{
    public class ANHSPService : IService<ANHSP>
    {
        private Shop_MVC_Context dataContext = new Shop_MVC_Context();

        public ANHSP Add(ANHSP entity, ref string err)
        {
            try
            {
                dataContext.ANHSPs.Add(entity);
                dataContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return new ANHSP();
            }
        }

        public bool Delete(int id, ref string err)
        {
            try
            {
                ANHSP entity = dataContext.ANHSPs.Find(id);
                dataContext.ANHSPs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool Delete(ANHSP entity, ref string err)
        {
            try
            {
                dataContext.ANHSPs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public ANHSP Find(int id, ref string err)
        {
            ANHSP entity = dataContext.ANHSPs.Find(id);
            if (entity == null)
            {
                err = "Không tìm thấy";
                return null;
            }

            return entity;
        }

        public IList<ANHSP> getAll()
        {
            return dataContext.ANHSPs.ToList();
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

        public bool Update(ANHSP entity, ref string err)
        {
            try
            {
                ANHSP tgz = dataContext.ANHSPs.Find(entity.ID);

                tgz.SRC = entity.SRC;
                tgz.MATHANGID = entity.MATHANGID;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}