using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult KategoriEkle(TBLKATEGORI p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle"); //Bu kısım modal olarak tasarlanma denenecek.
            }
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)//bunları method yapmak mantıklı mı? yapılır mı? neler method yapılır?
        {
            var kategori = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriGetir");
            }
            //var kategori = db.TBLKATEGORI.Find(p.ID);
            /* kategori.AD = p.AD;*/ //Bu işlemi diğer projeden bakalım bi farklı yapıyo olabiliriz orada
            db.Entry(p).State = System.Data.Entity.EntityState.Modified; 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}