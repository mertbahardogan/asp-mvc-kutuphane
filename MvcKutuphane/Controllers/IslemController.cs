using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.CustomClasses;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [CustomAuthorization(LoginPage = "~/AdminLogin/GirisYap/")]
    public class IslemController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Islem
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}