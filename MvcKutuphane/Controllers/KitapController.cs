using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Kitap
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
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
            //method yapabilir miyiz deneyelim
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP kitap)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("KitapGetir");
            //}
            var ktg = db.TBLKATEGORI.Where(k => k.ID == kitap.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == kitap.TBLYAZAR.ID).FirstOrDefault();
            kitap.TBLKATEGORI = ktg;
            kitap.TBLYAZAR = yzr;
            db.TBLKITAP.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            //if (!ModelState.IsValid)
            //{
            //    return View("KitapGetir"); 
            ////}
            var kitap = db.TBLKITAP.Find(p.ID);
            kitap.AD = p.AD;
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.YAYINEVI = p.YAYINEVI;
            kitap.SAYFA = p.SAYFA;
            kitap.DURUM = true; //aslında bu olmamalı
            //db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}