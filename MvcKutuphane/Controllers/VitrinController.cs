using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Classes;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Vitrin

        [Route("AnaSayfa/Index/")]
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKITAP.ToList();
            cs.Deger2 = db.TBLHAKKIMIZDA.ToList();
            return View(cs);
            //var degerler = db.TBLKITAP.ToList();
        }

        [Route("AnaSayfa/Index/")]
        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            t.TARIH = DateTime.Today;
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            TempData.Add("iletisim", "Mesajınız başarıyla gönderildi!");
            return RedirectToAction("Index");
        }
    }
}