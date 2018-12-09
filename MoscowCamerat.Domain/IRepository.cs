using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowCamerat.Domain
{
    public interface IRepository
    {
        ICollection SqlQuery(string sql);
        ICollection SqlQueryMethod(string sql, int id);
        ICollection SqlQueryMethod(string sql, int id, int id1);
        ICollection SqlQueryLogin(string sql, string email, string password);

        int SqlQueryGetInt(string sql);

        #region Lesson

        IQueryable<Lesson> Lesson { get; }

        bool CreateLesson(Lesson instance);

        bool UpdateLesson(Lesson instance);

        bool RemoveLesson(int idLesson);

        #endregion

        #region Material

        IQueryable<Material> Material { get; }

        bool CreateMaterial(Material instance);

        bool UpdateMaterial(Material instance);

        bool RemoveMaterial(int idMaterial);

        #endregion

        #region Video

        IQueryable<Video> Video { get; }

        bool CreateVideo(Video instance);

        bool UpdateVideo(Video instance);

        bool RemoveVideo(int idVideo);

        #endregion

        #region Photo

        IQueryable<Photo> Photo { get; }

        bool CreatePhoto(Photo instance);

        bool UpdatePhoto(Photo instance);

        bool RemovePhoto(int idPhoto);

        #endregion

        #region Plan

        IQueryable<Plan> Plan { get; }

        bool CreatePlan(Plan instance);

        bool UpdatePlan(Plan instance);

        bool RemovePlan(int idPlan);

        #endregion

        #region Method

        IQueryable<Method> Method { get; }

        bool CreateMethod(Method instance);

        bool UpdateMethod(Method instance);

        bool RemoveMethod(int idMethod);

        #endregion

        #region Account

        IQueryable<Account> Account { get; }

        bool CreateAccount(Account instance);

        bool UpdateAccount(Account instance);

        bool RemoveAccount(int idAccount);

        #endregion
    }
}
