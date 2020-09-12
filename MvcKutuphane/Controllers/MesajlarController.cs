using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [Authorize]
    public class MesajlarController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Mesajlar
        public ActionResult Index()
        {
            if ((string)Session["Mail"] == null)
            {
                return RedirectToAction("GirisYap","Login");
            }
            else
            {
                var uyeMail = (string)Session["Mail"]; //.ToString()
                var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyeMail.ToString()).ToList();
                return View(mesajlar);
            }
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            if ((string)Session["Mail"] == null)
            {
                return RedirectToAction("GirisYap", "Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR m)
        {
            var uyeMail = (string)Session["Mail"]; //.ToString()
            db.TBLMESAJLAR.Add(m);
            m.GONDEREN = uyeMail.ToString();
            m.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SaveChanges();
            return RedirectToAction("Gonderilen");
        }
        public ActionResult Gonderilen()
        {
            if ((string)Session["Mail"] == null)
            {
                return RedirectToAction("GirisYap", "Login");
            }
            else
            {
                var uyeMail = (string)Session["Mail"]; 
                var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyeMail.ToString()).ToList();
                return View(mesajlar);
            }
        }
    }
}