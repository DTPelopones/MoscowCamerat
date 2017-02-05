using System;
using System.Linq;


namespace MoscowCamerat.Domain
{
    public partial class SqlRepository
    {
        public IQueryable<Lesson> Lesson
        {
            get
            {
                return Db.Lesson;
            }
        }

        public bool CreateLesson(Lesson instance)
        {
            if (instance.ID == 0)
            {
                Db.Lesson.InsertOnSubmit(instance);
                Db.Lesson.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateLesson(Lesson instance)
        {
            Lesson cache = Db.Lesson.FirstOrDefault(p => p.ID == instance.ID);
            if (instance.ID == 0)
            {
                cache.name = instance.name;
                cache.sort = instance.sort;
                Db.Lesson.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveLesson(int idLesson)
        {
            Lesson instance = Db.Lesson.FirstOrDefault(p => p.ID == idLesson);
            if (instance != null)
            {
                Db.Lesson.DeleteOnSubmit(instance);
                Db.Lesson.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
