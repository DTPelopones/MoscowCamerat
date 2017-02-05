using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoscowCamerat.Domain;
using System.Web.Mvc;

namespace MoscowCamerat.Controllers
{
    public class VideoController : BaseController
    {
        // GET: Video
        public ActionResult Index()
        {
            return View();
        }
    }
}