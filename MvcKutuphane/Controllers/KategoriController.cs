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
            var degerler = db.TBLKATEGORI.Where(x => x.DURUM == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View("KategoriEkle");
        }
        [HttpGet]
        public ActionResult ekle(String kategoriAdi) //adı önemli değil
        {
            if (!ModelState.IsValid && kategoriAdi == "" && kategoriAdi.Length<=2)
            {
                return RedirectToAction("Index");
            }

            TBLKATEGORI yeni = new TBLKATEGORI();

            yeni.AD = kategoriAdi;
            db.TBLKATEGORI.Add(yeni);
            yeni.DURUM = true;
            db.SaveChanges();
            return Json(new { success = true, message = "Başarıyla Eklendi." }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            else
            {
                //db.TBLKATEGORI.Remove(kategori);
                kategori.DURUM = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
        public ActionResult Pasif()
        {
            var degerler = db.TBLKATEGORI.Where(x => x.DURUM == false).ToList();
            return View(degerler);
        }
        public ActionResult GeriGetir(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            else
            {
                kategori.DURUM = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}