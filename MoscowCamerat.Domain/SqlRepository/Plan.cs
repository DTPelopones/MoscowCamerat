using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowCamerat.Domain
{
    public partial class SqlRepository
    {
        public IQueryable<Plan> Plan
        {
            get
            {
                return Db.Plan;
            }
        }

        public bool CreatePlan(Plan instance)
        {
            if (instance.ID == 0)
            {
                Db.Plan.InsertOnSubmit(instance);
                Db.Plan.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdatePlan(Plan instance)
        {
            Plan cache = Db.Plan.FirstOrDefault(p => p.ID == instance.ID);
            if (instance.ID == 0)
            {
                cache.name = instance.name;
                cache.MaterialID = instance.MaterialID;
                cache.MethodID = instance.MethodID;
                cache.sort = instance.sort;
                Db.Plan.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemovePlan(int idPlan)
        {
            Plan instance = Db.Plan.FirstOrDefault(p => p.ID == idPlan);
            if (instance != null)
            {
                Db.Plan.DeleteOnSubmit(instance);
                Db.Plan.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
