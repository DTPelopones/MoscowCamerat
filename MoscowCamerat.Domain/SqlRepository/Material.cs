using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowCamerat.Domain
{
    public partial class SqlRepository
    {
        public IQueryable<Material> Material
        {
            get
            {
                return Db.Material;
            }
        }

        public bool CreateMaterial(Material instance)
        {
            if (instance.ID == 0)
            {
                Db.Material.InsertOnSubmit(instance);
                Db.Material.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateMaterial(Material instance)
        {
            Material cache = Db.Material.FirstOrDefault(p => p.ID == instance.ID);
            if (instance.ID == 0)
            {
                cache.LessonID = instance.LessonID;
                cache.VideoID = instance.VideoID;
                Db.Material.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveMaterial(int idMaterial)
        {
            Material instance = Db.Material.FirstOrDefault(p => p.ID == idMaterial);
            if (instance != null)
            {
                Db.Material.DeleteOnSubmit(instance);
                Db.Material.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
