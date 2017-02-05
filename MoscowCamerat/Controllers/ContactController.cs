using System.Web.Mvc;
using System.Net.Mail;
using System;
using MoscowCamerat.Models;

namespace MoscowCamerat.Controllers
{
    public class ContactController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(EmailModel model)
        {
            sendEmail(model);
            return PartialView("ErrorPartEmail", model); 
        }
    }
}