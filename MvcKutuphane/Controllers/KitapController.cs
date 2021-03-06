﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcKutuphane.CustomClasses;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKutuphane.Controllers
{
    [CustomAuthorization(LoginPage = "~/AdminLogin/GirisYap/")]
    public class KitapController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kitap
        public ActionResult Index(int sayfa = 1)
        {
            var kitaplar = db.TBLKITAP.ToList().ToPagedList(sayfa, 6);
            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> k = new List<SelectListItem>();
            foreach (var item in db.TBLKATEGORI.ToList())
            {
                k.Add(new SelectListItem
                {
                    Text = item.AD,
                    Value = item.ID.ToString()
                });
            }
            ViewBag.KATEGORI = k;

            List<SelectListItem> y = new List<SelectListItem>();
            foreach (var item in db.TBLYAZAR.ToList())
            {
                y.Add(new SelectListItem
                {
                    Text = item.AD + ' ' + item.SOYAD,
                    Value = item.ID.ToString()
                });
            }
            ViewBag.YAZAR = y;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP kitap)
        {
            if (!ModelState.IsValid)
            {
                return View("KitapEkle");
            }
            var kitapSorgu = db.TBLKITAP.FirstOrDefault(x => x.AD == kitap.AD);
            if (kitapSorgu != null)
            {
                TempData.Add("errorKitap", "Bu ada ait kitap bulunuyor.");
                return RedirectToAction("Index");
            }
            var ktg = db.TBLKATEGORI.Where(k => k.ID == kitap.KATEGORI).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == kitap.YAZAR).FirstOrDefault();
            kitap.TBLKATEGORI = ktg;
            kitap.TBLYAZAR = yzr;
            db.TBLKITAP.Add(kitap);
            if (kitap.KITAPRESIM == null)
            {
                kitap.KITAPRESIM = "https://i.imgyukle.com/2020/05/02/rTu0rc.jpg";
            }
            db.SaveChanges();
            return RedirectToAction("KitapEkle");
        }

        public ActionResult KitapSil(int id)
        {
            var kt = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TBLKITAP.Find(id);

            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(TBLKITAP p)
        {
            var kitap = db.TBLKITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            kitap.DURUM = true;
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            if (kitap.KITAPRESIM == null)
            {
                kitap.KITAPRESIM = "https://i.imgyukle.com/2020/05/02/rTu0rc.jpg";
            }
            else { kitap.KITAPRESIM = p.KITAPRESIM; }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}