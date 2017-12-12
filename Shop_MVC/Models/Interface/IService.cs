using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_MVC.Models.Interface
{
    interface IService<T> where T : class
    {
        T Add(T entity, ref string err);
        bool Update(T entity, ref string err);
        bool Delete(T entity, ref string err);
        bool Delete(int id, ref string err);
        T Find(int id, ref string err);
        IList<T> getAll();
        bool Save(ref string err);
    }
}
