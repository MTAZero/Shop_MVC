using Shop_MVC.Models.Db;
using Shop_MVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_MVC.Models.Service
{
    public class LOAISANPHAMService : IService<LOAISANPHAM>
    {
        private Shop_MVC_Context dataContext = new Shop_MVC_Context();

        public LOAISANPHAM Add(LOAISANPHAM entity, ref string err)
        {
            try
            {
                dataContext.LOAISANPHAMs.Add(entity);
                dataContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return new LOAISANPHAM();
            }
        }

        public bool Delete(int id, ref string err)
        {
            try
            {
                LOAISANPHAM entity = dataContext.LOAISANPHAMs.Find(id);
                dataContext.LOAISANPHAMs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool Delete(LOAISANPHAM entity, ref string err)
        {
            try
            {
                dataContext.LOAISANPHAMs.Remove(entity);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public LOAISANPHAM Find(int id, ref string err)
        {
            LOAISANPHAM entity = dataContext.LOAISANPHAMs.Find(id);
            if (entity == null)
            {
                err = "Không tìm thấy";
                return null;
            }

            return entity;
        }

        public IList<LOAISANPHAM> getAll()
        {
            return dataContext.LOAISANPHAMs.ToList();
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

        public bool Update(LOAISANPHAM entity, ref string err)
        {
            try
            {
                LOAISANPHAM tgz = dataContext.LOAISANPHAMs.Find(entity.ID);

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