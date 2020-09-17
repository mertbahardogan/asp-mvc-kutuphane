using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Panel

        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == uyemail);
           
            List<SelectListItem> uyeOkul = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Hacettepe Üniversitesi", Value = "Hacettepe Üniversitesi"
        },
        new SelectListItem {
            Text = "Orta Doğu Teknik Üniversitesi", Value = "Orta Doğu Teknik Üniversitesi"
        },
        new SelectListItem {
            Text = "Bilkent Üniversitesi", Value = "Bilkent Üniversitesi"
        },
    };
            ViewBag.UyeOkul = uyeOkul;
            if (degerler == null)
            {
                return RedirectToAction("GirisYap", "Login");
            }
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            if (p.SIFRE != uye.SIFRE)
            {
                uye.SIFRE = Crypto.Hash(p.SIFRE, "MD5");
                uye.SIFREONAY = Crypto.Hash(p.SIFREONAY, "MD5");
            }
            uye.AD = p.AD;
            uye.OKUL = p.OKUL;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.KADI = p.KADI;
            uye.SOZLESME = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitap(int sayfa = 1)
        {
            if ((string)Session["Mail"] == null)
            {
                return RedirectToAction("GirisYap", "Login");
            }
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            //var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList().ToPagedList(sayfa, 7);
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            if ((string)Session["Mail"] == null)
            {
                return RedirectToAction("GirisYap", "Login");
            }
            var duyurular = db.TBLDUYURU.Where(d => d.DURUM == true).ToList();
            return View(duyurular);
        }

        public ActionResult DuyuruOkundu(int id)
        {
            var duyuru = db.TBLDUYURU.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            else
            {
                //db.TBLKATEGORI.Remove(kategori);
                duyuru.DURUM = false;
                db.SaveChanges();
                return RedirectToAction("Duyurular", "Panel");
            }
        }

        public ActionResult DuyuruOkunmus()
        {
            var degerler = db.TBLDUYURU.Where(x => x.DURUM == false).ToList();
            return View(degerler);
        }
    }
}