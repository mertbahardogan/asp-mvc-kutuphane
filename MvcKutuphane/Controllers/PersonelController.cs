using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.CustomClasses;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [CustomAuthorization(LoginPage = "~/AdminLogin/GirisYap/")]
    public class PersonelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
            ViewBag.mesaj = "Tablosu başarıyla listelendi.";
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            TempData.Add("personel", p.PERSONEL + " adlı personel başarıyla eklendi.");
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var per = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(per);
            db.SaveChanges();
            TempData.Add("personel", per.PERSONEL + " adlı personel başarıyla silindi."); //HAta var
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", personel);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGetir");
            }
            //var personel = db.TBLPERSONEL.Find(p.ID);
            //personel.PERSONEL = p.PERSONEL;
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ProfilGuncelle()
        {
            var personelKadi = (string)Session["kullaniciAdi"];
            var degerler = db.TBLPERSONEL.FirstOrDefault(x => x.KullaniciAdi == personelKadi);

            if (personelKadi == null)
            {
                return RedirectToAction("GirisYap", "AdminLogin");
            }
            return View(degerler);
        }

        [HttpPost]
        public ActionResult ProfilGuncelle2(TBLPERSONEL veri)
        {
            var personelKadi = (string)Session["kullaniciAdi"];
            var veriPersonel = db.TBLPERSONEL.FirstOrDefault(x => x.KullaniciAdi == personelKadi);

            veriPersonel.KullaniciAdi = veri.KullaniciAdi;
            veriPersonel.PERSONEL = veri.PERSONEL;
            veriPersonel.Sifre = veri.Sifre;
            veriPersonel.Fotograf = veri.Fotograf;
            TempData.Add("profil", "Profiliniz başarıyla güncellendi.");
            db.SaveChanges();
            return RedirectToAction("ProfilGuncelle");
        }
    }
}