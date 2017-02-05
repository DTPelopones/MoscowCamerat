using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowCamerat.Domain
{
    public partial class SqlRepository
    {
        public IQueryable<Method> Method
        {
            get
            {
                return Db.Method;
            }
        }

        public bool CreateMethod(Method instance)
        {
            if (instance.ID == 0)
            {
                Db.Method.InsertOnSubmit(instance);
                Db.Method.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateMethod(Method instance)
        {
            Method cache = Db.Method.FirstOrDefault(p => p.ID == instance.ID);
            if (instance.ID == 0)
            {
                cache.ParentID = instance.ParentID;
                cache.name = instance.name;
                cache.sort = instance.sort;
                Db.Method.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveMethod(int idMethod)
        {
            Method instance = Db.Method.FirstOrDefault(p => p.ID == idMethod);
            if (instance != null)
            {
                Db.Method.DeleteOnSubmit(instance);
                Db.Method.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
