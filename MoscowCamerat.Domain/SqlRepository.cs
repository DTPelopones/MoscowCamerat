using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace MoscowCamerat.Domain
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public LessonDataContext Db { get; set; }

        public virtual ICollection SqlQueryMethod(string sql, int id)
        {
            return Db.ExecuteQuery<Method>(sql, id).ToList();
        }

        public virtual ICollection SqlQueryMethod(string sql, int id, int id1)
        {
            return Db.ExecuteQuery<Method>(sql, id, id1).ToList();
        }

        public virtual ICollection SqlQuery(string sql)
        {
            return Db.ExecuteQuery<IRepository>(sql).ToList();
        }

        public virtual ICollection SqlQueryLogin(string sql, string email, string password)
        {
            return Db.ExecuteQuery<Account>(sql, email, password).ToList();
        }

        public virtual int SqlQueryGetInt(string sql)
        {
            return Db.ExecuteQuery<int>(sql).ToList().First();
        }
    }

}
