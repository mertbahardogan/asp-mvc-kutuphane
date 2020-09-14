using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcKutuphane.Controllers
{
    public class KayitController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kayit
        [HttpGet]
        public ActionResult YeniKayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKayit(TBLUYELER uye)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKayit");
            }
            uye.SIFREONAY = uye.SIFRE;
            uye.SIFRE = Crypto.Hash(uye.SIFRE, "MD5");
            uye.SIFREONAY = Crypto.Hash(uye.SIFREONAY, "MD5");
            if (uye.FOTOGRAF == null)
            {
                uye.FOTOGRAF = "https://i.imgyukle.com/2020/08/04/Sw4Upt.png";
            }
            db.TBLUYELER.Add(uye);
            db.SaveChanges();
            TempData["Kontrol"] = "Kaydınız oluşturuldu.";
            return RedirectToAction("GirisYap", "Login");
        }
    }
}