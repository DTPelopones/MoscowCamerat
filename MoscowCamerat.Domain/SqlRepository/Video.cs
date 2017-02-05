using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowCamerat.Domain
{
    public partial class SqlRepository
    {
        public IQueryable<Video> Video
        {
            get
            {
                return Db.Video;
            }

        }

        public bool CreateVideo(Video instance)
        {
            if (instance.ID == 0)
            {
                Db.Video.InsertOnSubmit(instance);
                Db.Video.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateVideo(Video instance)
        {
            Video cache = Db.Video.FirstOrDefault(p => p.ID == instance.ID);
            if (instance.ID == 0)
            {
                cache.name = instance.name; 
                cache.path = instance.path; 
                cache.type = instance.type;
                cache.movieTime = instance.movieTime; 
                Db.Video.Context.SubmitChanges(); 
                return true;
            }
            return false;
        }

        public bool RemoveVideo(int idVideo)
        {
            Video instance = Db.Video.FirstOrDefault(p => p.ID == idVideo);
            if (instance != null)
            {
                Db.Video.DeleteOnSubmit(instance);
                Db.Video.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
