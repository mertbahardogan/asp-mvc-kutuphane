using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class AdminLoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: AdminLogin
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLPERSONEL personel)
        {
            var bilgiler = db.TBLPERSONEL.FirstOrDefault(x => x.KullaniciAdi == personel.KullaniciAdi && x.Sifre == personel.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Response.Cookies["USER_ID"].Value = bilgiler.KullaniciAdi;
                Response.Cookies["USER_ID"].Expires = DateTime.Now.AddDays(1);
                Session["kullaniciAdi"] = bilgiler.KullaniciAdi;
                Session["personel"] = bilgiler.PERSONEL;
                Session["foto"] = bilgiler.Fotograf;
                Session["yetki"] = bilgiler.Rol;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Kontrol"] = "Kullanıcı adı yada parola yanlış.";
                return View();
            }
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Response.Cookies["USER_ID"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("GirisYap");
        }
    }
}