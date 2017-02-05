using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowCamerat.Domain
{
    public partial class SqlRepository
    {
        public IQueryable<Photo> Photo
        {
            get
            {
                return Db.Photo;
            }
        }

        public bool CreatePhoto(Photo instance)
        {
            if (instance.ID == 0)
            {
                Db.Photo.InsertOnSubmit(instance);
                Db.Photo.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdatePhoto(Photo instance)
        {
            Photo cache = Db.Photo.FirstOrDefault(p => p.ID == instance.ID);
            if (instance.ID == 0)
            {
                cache.name = instance.name;
                cache.path = instance.path;
                cache.type = instance.type;
                cache.album = instance.album;
                cache.size = instance.size;
                cache.sizem = instance.sizem;
                cache.pathm = instance.pathm;
                cache.sort = instance.sort;
                cache.alt = instance.alt;
                cache.eventTime = instance.eventTime;
                cache.eventDay = instance.eventDay;
                cache.eventMonthYear = instance.eventMonthYear;
                cache.eventDesc = instance.eventDesc;
                cache.description = instance.description;
                cache.movieTime = instance.movieTime;
                Db.Photo.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemovePhoto(int idPhoto)
        {
            Photo instance = Db.Photo.FirstOrDefault(p => p.ID == idPhoto);
            if (instance != null)
            {
                Db.Photo.DeleteOnSubmit(instance);
                Db.Photo.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
