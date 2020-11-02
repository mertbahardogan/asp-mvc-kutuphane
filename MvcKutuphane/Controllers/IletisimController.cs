using MvcKutuphane.CustomClasses;
using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    [CustomAuthorization(LoginPage = "~/AdminLogin/GirisYap/")]
    public class IletisimController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Iletisim
        public ActionResult Index()
        {
            var iletisim = db.TBLILETISIM.ToList();
            return View(iletisim);
        }


        public ActionResult IletisimSil(int id)
        {
            var il = db.TBLILETISIM.Find(id);
            db.TBLILETISIM.Remove(il);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}