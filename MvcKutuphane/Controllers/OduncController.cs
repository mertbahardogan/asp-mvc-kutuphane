using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> uye = (from x in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD+" "+x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.UYE = uye;
            List<SelectListItem> kitap = (from y in db.TBLKITAP.Where(e=>e.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD,
                                               Value = y.ID.ToString()
                                           }).ToList();
            ViewBag.KITAP = kitap;
            List<SelectListItem> personel = (from z in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.PERSONEL,
                                               Value = z.ID.ToString()
                                           }).ToList();
            ViewBag.PERSONEL = personel;

            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            var uyeler = db.TBLUYELER.Where(uye => uye.ID == p.TBLUYELER.ID).FirstOrDefault();
            var kitaplar = db.TBLKITAP.Where(kitap => kitap.ID == p.TBLKITAP.ID).FirstOrDefault();
            var personeller = db.TBLPERSONEL.Where(personel => personel.ID == p.TBLPERSONEL.ID).FirstOrDefault();
            p.TBLUYELER = uyeler;
            p.TBLKITAP = kitaplar;
            p.TBLPERSONEL = personeller;
            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OduncIade(TBLHAREKET p)
        {
            var odn = db.TBLHAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            
            TimeSpan d3 = d2 - d1;
            if (d3.TotalDays < 0)
            {
                ViewBag.dgr = 0;
            }
            else
            {
                ViewBag.dgr = d3.TotalDays;
            }
            return View("OduncIade", odn);
        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrk = db.TBLHAREKET.Find(p.ID);
            hrk.GETIRILENTARIH = p.GETIRILENTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}