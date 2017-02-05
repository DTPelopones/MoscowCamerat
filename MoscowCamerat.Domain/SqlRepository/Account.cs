using System;
using System.Linq;


namespace MoscowCamerat.Domain
{
    public partial class SqlRepository
    {
        public IQueryable<Account> Account
        {
            get
            {
                return Db.Account;
            }
        }

        public bool CreateAccount(Account instance)
        {
            if (instance.ID == 0)
            {
                Db.Account.InsertOnSubmit(instance);
                Db.Account.Context.SubmitChanges();
                return true;
            }

            return false;
        }

        public bool UpdateAccount(Account instance)
        {
            Account cache = Db.Account.FirstOrDefault(p => p.ID == instance.ID);
            if (instance.ID == 0)
            {
                cache.name = instance.name;
                cache.email = instance.email;
                Db.Account.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveAccount(int idAccount)
        {
            Account instance = Db.Account.FirstOrDefault(p => p.ID == idAccount);
            if (instance != null)
            {
                Db.Account.DeleteOnSubmit(instance);
                Db.Account.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
