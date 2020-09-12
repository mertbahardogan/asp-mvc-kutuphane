using MvcKutuphane.Models.Entity;
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
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Istatistik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kur()
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
                if ( dosya!=null)
                {
                    TempData["basarili"] = "Yükleme Başarılı.";
                    string dosyayolu = Path.Combine(Server.MapPath("~/Content/img/"), Path.GetFileName(dosya.FileName));
                    dosya.SaveAs(dosyayolu);

                }
                else
                {
                    TempData["basarisiz"] = "Yükleme Başarısız.";
                    return RedirectToAction("Galeri", "Istatistik");
                }
            }
            catch (Exception)
            {

                TempData["basarisiz"] = "Yükleme Başarısız.";
            }
            return RedirectToAction("Galeri", "Istatistik");
        }
    }
}