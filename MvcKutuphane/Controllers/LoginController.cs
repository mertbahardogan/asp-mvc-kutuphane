using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLUYELER uye)
        {
            var mdfive = Crypto.Hash(uye.SIFRE, "MD5");
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == uye.MAIL && x.SIFRE == mdfive);
            //var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == uye.MAIL && x.SIFRE == uye.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);        //Beni hatırla için false olan değer değişti. uye.benihatirla
                Session["Mail"] = bilgiler.MAIL.ToString();
                Session["Fotograf"] = bilgiler.FOTOGRAF.ToString();
                Session["Ad"] = bilgiler.AD.ToString();
                Session["Soyad"] = bilgiler.SOYAD.ToString();
                return RedirectToAction("Index", "Panel");
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
            return RedirectToAction("GirisYap");
        }

        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SifremiUnuttum(string eposta)
        {
            var mail = db.TBLUYELER.Where(x => x.MAIL == eposta).SingleOrDefault();
            if (mail != null)
            {
                Random rnd = new Random();
                int yeniSifre = rnd.Next(1,10000000);

                TBLUYELER uye = new TBLUYELER();
                mail.SIFRE = Crypto.Hash(Convert.ToString(yeniSifre), "MD5");
                db.SaveChanges();

                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "workcoderm@gmail.com";
                WebMail.Password = "F.ener-bahce367";
                WebMail.SmtpPort = 587;
                WebMail.Send(eposta,"MVC5 Kütüphane Paneli","Yeni Şifreniz: "+yeniSifre);
                ViewBag.Uyari = "Mail başarıyla gönderildi. Lütfen kontrol ediniz.";
            }
            else
            {
                ViewBag.Uyari = "Hata oluştu. Tekrar deneyiniz!";
            }
            return View();
        }
    }
}