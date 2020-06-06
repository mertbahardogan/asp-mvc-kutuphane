using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HavaDurumu()
        {
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            var TempDataBasarili = TempData["basarili"];
            var TempDataBasarisiz = TempData["basarisiz"];
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            try
            {

                if (dosya.ContentLength > 0)
                {
                    TempData["basarili"] = "Yükleme Başarılı.";
                    string dosyayolu = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(dosyayolu);

                }
                if (dosya.ContentLength <= 0)
                {
                    return View("Index");
                }
            }
            catch (Exception)
            {

                TempData["basarisiz"] = "Yükleme Başarısız.";
            }

            return RedirectToAction("Galeri");
        }
    }
}