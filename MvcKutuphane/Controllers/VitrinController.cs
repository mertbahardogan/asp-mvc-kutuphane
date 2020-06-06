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

        [HttpGet]
        public ActionResult Index()
        {
            //Sadece classes için ıenumerable ekledik ve buraya geldik
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKITAP.ToList(); 
            cs.Deger2 = db.TBLHAKKIMIZDA.ToList();
            return View(cs);

            //var degerler = db.TBLKITAP.ToList();
        }

        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}