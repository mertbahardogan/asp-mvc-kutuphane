using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcKutuphane.CustomClasses;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [CustomAuthorization(LoginPage = "~/AdminLogin/GirisYap/")]
    public class UyeController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Uye
        public ActionResult Index()
        {
            var degerler = db.TBLUYELER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            List<SelectListItem> adminOkul = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Hacettepe Üniversitesi", Value = "Hacettepe Üniversitesi"
        },
        new SelectListItem {
            Text = "Orta Doğu Teknik Üniversitesi", Value = "Orta Doğu Teknik Üniversitesi"
        },
        new SelectListItem {
            Text = "Bilkent Üniversitesi", Value = "Bilkent Üniversitesi"
        },
    };
            ViewBag.uyeAdminOkul = adminOkul;

            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL);
            if (uye != null)
            {
                TempData.Add("errorUye", "Bu mail adresi kullanılmaktadır.");
                return RedirectToAction("Index");
            }
            p.SIFRE = Crypto.Hash(p.SIFRE, "MD5");
            p.SIFREONAY = Crypto.Hash(p.SIFREONAY, "MD5");
            p.SOZLESME = true;
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            List<SelectListItem> adminOkul = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Hacettepe Üniversitesi", Value = "Hacettepe Üniversitesi"
        },
        new SelectListItem {
            Text = "Orta Doğu Teknik Üniversitesi", Value = "Orta Doğu Teknik Üniversitesi"
        },
        new SelectListItem {
            Text = "Bilkent Üniversitesi", Value = "Bilkent Üniversitesi"
        },
    };
            ViewBag.uyeAdminOkul = adminOkul;
            var uye = db.TBLUYELER.Find(id);


            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeGetir");
            }
            var uye = db.TBLUYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KADI = p.KADI;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            if(p.SIFRE!=uye.SIFRE)
            {
                uye.SIFRE = Crypto.Hash(p.SIFRE, "MD5");
                uye.SIFREONAY = Crypto.Hash(p.SIFREONAY, "MD5");
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGecmis(int id)
        {
            var gec = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyeAd = db.TBLUYELER.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.uAd = uyeAd;


            return View(gec);
        }
    }
}