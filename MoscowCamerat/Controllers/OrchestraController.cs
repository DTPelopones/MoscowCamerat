using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using MoscowCamerat.Domain;

namespace MoscowCamerat.Controllers
{
    public class OrchestraController : BaseController
    {
        int pageSize = 24;
        public ActionResult Index(int? page)
        {
            string album = "Orchestra";
            IEnumerable<Photo> photoes = null;
            if (!page.HasValue)
            {
                photoes = repository.Photo.Where(f => f.path.Contains(album)).Where(f => f.sort != null).OrderBy(f => f.sort).Take(pageSize);
            }
            else
            {
                int pageIndex = pageSize * page.Value;
                photoes = repository.Photo.Where(f => f.path.Contains(album)).Where(f => f.sort != null).OrderBy(f => f.sort).Skip(pageIndex).Take(pageSize);
            }

            ViewBag.sendingProgress = "display: none;";
            ViewBag.album = album;

            if (Request.IsAjaxRequest())
            {
                return PartialView("OrchestraPart", photoes);
            }
            return View(photoes);
        }
    }
}