using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Classes;

namespace MvcKutuphane.Controllers
{
    public class HomeController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Home
        public ActionResult Index()
        {
            HomeClass cs = new HomeClass();
            cs.DegerX = db.TBLILETISIM.ToList();
            cs.DegerY = db.TBLHAREKET.Where(x=>x.ISLEMDURUM==true).ToList();
            var deger1 = db.TBLCEZALAR.Sum(x => x.PARA);
            var deger2 = db.TBLILETISIM.Where(d=>d.TARIH==DateTime.Today).Count();
            var deger3 = db.TBLUYELER.Count();
            var islemsayi = db.TBLHAREKET.Where(x=>x.ISLEMDURUM==true && x.GETIRILENTARIH==DateTime.Today).Count();
            var gunlukkazanc = db.GunlukKazanilan().Sum();
            var encokokunan = db.CokOkunanKitap().FirstOrDefault();
            var sonverilenkitap = db.BugünVerilenKitap().FirstOrDefault();
            var gunlukemanet = db.BugunVerilenKitapSayisi().FirstOrDefault();
            var enuye = db.EnAktifUye().FirstOrDefault();
            var enpersonel = db.BasariliPersonel().FirstOrDefault();
            var enyazar = db.EnFazlaKitapYazar().FirstOrDefault();
            var uye = db.TBLUYELER.Count();
            var personel = db.TBLPERSONEL.Count();
            var kitap = db.TBLKITAP.Count();
            var yazar = db.TBLYAZAR.Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgrislem = islemsayi;
            ViewBag.dgrgk = gunlukkazanc;
            ViewBag.dgrkitap = encokokunan;
            ViewBag.dgrkitapson = sonverilenkitap;
            ViewBag.gunlukemanet = gunlukemanet;
            ViewBag.enuye = enuye;
            ViewBag.enpersonel = enpersonel;
            ViewBag.enyazar = enyazar;
            ViewBag.uye = uye;
            ViewBag.personel = personel;
            ViewBag.kitap = kitap;
            ViewBag.yazar = yazar;
            return View(cs);
        }
    }
}