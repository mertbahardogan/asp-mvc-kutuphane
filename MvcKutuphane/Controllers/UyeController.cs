using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        public string Cyrpto { get; private set; }

        // GET: Uye
        public ActionResult Index()
        {
            var degerler = db.TBLUYELER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("PageError", "Error");
            }
            p.SIFREONAY = p.SIFRE;
            p.SIFRE = Crypto.Hash(p.SIFRE, "MD5");
            p.SIFREONAY = Crypto.Hash(p.SIFREONAY, "MD5");
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
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeGetir");
            }
            //var uye = db.TBLUYELER.Find(p.ID);
            //uye.AD = p.AD;
            //uye.SOYAD = p.SOYAD;
            //uye.MAIL = p.MAIL;
            //uye.KADI = p.KADI;
            //uye.SIFRE = p.SIFRE;
            //uye.OKUL = p.OKUL;
            //uye.TELEFON = p.TELEFON;
            //uye.FOTOGRAF = p.FOTOGRAF;
            p.SIFREONAY = p.SIFRE;
            p.SIFRE = Crypto.Hash(p.SIFRE, "MD5");
            p.SIFREONAY = Crypto.Hash(p.SIFREONAY, "MD5");
            p.SOZLESME = true;
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
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