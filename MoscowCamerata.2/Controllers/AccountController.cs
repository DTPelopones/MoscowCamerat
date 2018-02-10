using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoscowCamerat.Domain;

namespace MoscowCamerata2.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
            //return View();
        }

        [HttpPost]
        public PartialViewResult Login(string email, string password_hash)
        {
            if (ModelState.IsValid)
            {
                string query = "select a.* from dbo.fn_login({0},{1}) as a;";
                byte[] data = System.Text.Encoding.Unicode.GetBytes(password_hash);
                System.Security.Cryptography.MD5CryptoServiceProvider passw = new System.Security.Cryptography.MD5CryptoServiceProvider();
                data = passw.ComputeHash(data);
                String md5pass = "0x";
                foreach (var b in data)
                {
                    md5pass += b.ToString("X2");
                }
                var acc = repository.SqlQueryLogin(query, email, md5pass);
                ViewBag.Account = acc; 
                if (acc != null)
                {
                    Session["AccountID"] = ((ICollection<Account>)acc).First().ID.ToString();
                    Session["AccountEmail"] = ((ICollection<Account>)acc).First().email.ToString();
                    Session["AccountName"] = ((ICollection<Account>)acc).First().name.ToString();
                    ViewBag.Account = ((ICollection<Account>)acc).First();
                    return PartialView("Login", ((ICollection<Account>)acc).First()); 
                }
            }
            return PartialView("Login", ViewBag.Account);
        }
    }
}