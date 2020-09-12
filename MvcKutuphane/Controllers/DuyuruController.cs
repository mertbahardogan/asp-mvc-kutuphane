using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Duyuru
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURU.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(TBLDUYURU t)
        {
            db.TBLDUYURU.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURU.Find(id);
            db.TBLDUYURU.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(int id)
        {
            var duyuru = db.TBLDUYURU.Find(id);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TBLDUYURU t)
        {
            if (!ModelState.IsValid)
            {
                return View("DuyuruDetay");
            }
            var duyuru = db.TBLDUYURU.Find(t.ID);
            //db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            duyuru.KATEGORI = t.KATEGORI;
            duyuru.ICERIK = t.ICERIK;
            duyuru.TARIH = t.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}