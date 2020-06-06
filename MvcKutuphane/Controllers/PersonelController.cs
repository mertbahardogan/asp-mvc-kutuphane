using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
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
            if (!ModelState.IsValid) //Validation için (modele display ekledik, buraya if ekledik, View kısmına html.validaton ekledik) 3 AŞAMA
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index"); //Bu kısımda yapıcağımız şey indexe eklenince dönmeden o sayfa içinde eklendi diye mesaj göstermek 
        }

        public ActionResult PersonelSil(int id)
        {
            var per=db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(per);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", personel);
        }

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
    }
}