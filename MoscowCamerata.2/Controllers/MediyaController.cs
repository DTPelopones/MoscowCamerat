using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using MoscowCamerat.Domain;

namespace MoscowCamerata2.Controllers
{
    public class MediyaController : BaseController
    {
        int pageSize = 24;
        public ActionResult Photo(int? page)
        {
            string album = "Concert";
            IEnumerable<Photo> photoes = null;
            if(!page.HasValue)
            {
                photoes = repository.Photo.Where(f=>f.path.Contains(album)).Where(f=>f.sort!=null).OrderBy(f => f.sort).Take(pageSize);
            }
            else
            {
                int pageIndex = pageSize * page.Value;
                photoes = repository.Photo.Where(f => f.path.Contains(album)).Where(f => f.sort != null).OrderBy(f=>f.sort).Skip(pageIndex).Take(pageSize);
            }
            ViewBag.album = album;

            if (Request.IsAjaxRequest())
            {
                return PartialView("PhotoPart", photoes);
            }
            return View(photoes);
        }

        //public ActionResult Audio()
        //{
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Video()
        //{
        //    return RedirectToAction("Index");
        //}

        public ActionResult Album()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            string album = "Orchestra";
            IEnumerable<Photo> photoes = null;
            photoes = repository.Photo.Where(f => f.path.Contains(album)).Where(f => f.sort != null).OrderBy(f => f.sort).Take(pageSize);
            ViewBag.album = album;

            if (Request.IsAjaxRequest())
            {
                return PartialView("PhotoPart", photoes);
            }
            return View(photoes);
            //return View(); 
        }

        //public ActionResult Album()
        //{
        //    return PartialView();
        //}

        //public ActionResult Audio()
        //{
        //    return PartialView();
        //}

        //public ActionResult Video()
        //{
        //    return PartialView();
        //}
    }
}
