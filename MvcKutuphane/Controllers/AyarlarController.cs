using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Ayarlar
        public ActionResult Index()
        {
            var ayar = db.TBLHAKKIMIZDA.ToList();
            return View(ayar);
        }

        public ActionResult AyarlarGetir(int id)
        {
            var ayarlar = db.TBLHAKKIMIZDA.Find(id);
            return View("Index", ayarlar);
        }

        public ActionResult AyarlarGuncelle(TBLHAKKIMIZDA p)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            var ayarlar = db.TBLHAKKIMIZDA.Find(1);
            ayarlar.ACIKLAMA = p.ACIKLAMA;
            ayarlar.ADRES = p.ADRES;
            ayarlar.OZET = p.OZET;
            ayarlar.FACEBOOK = p.FACEBOOK;
            ayarlar.TWITTER = p.TWITTER;
            ayarlar.LINKEDIN = p.LINKEDIN;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}