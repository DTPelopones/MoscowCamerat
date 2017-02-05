using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using MoscowCamerat.Domain;

namespace MoscowCamerat.Controllers
{
    public class AfishaController : BaseController
    {
        int pageSize = 24;
        public ActionResult Index(int? page)
        {
            string album = "Afisha";
            IEnumerable<Photo> photoes = null;
            if (!page.HasValue)
            {
                photoes = repository.Photo.Where(f => f.path.Contains(album)).OrderByDescending(f => f.sort).Take(pageSize);
            }
            else
            {
                int pageIndex = pageSize * page.Value;
                photoes = repository.Photo.Where(f => f.path.Contains(album)).OrderByDescending(f => f.sort).Skip(pageIndex).Take(pageSize);
            }

            ViewBag.sendingProgress = "display: none;";
            ViewBag.album = album;

            if (Request.IsAjaxRequest())
            {
                return PartialView("AfishaPart", photoes);
            }
            return View(photoes);
        }
    }
}