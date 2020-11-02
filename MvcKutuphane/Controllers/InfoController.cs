using MvcKutuphane.Models;
using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcKutuphane.Controllers
{
    public class InfoController : ApiController
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public IEnumerable<Personel> GetPersoneller() => db.TBLPERSONEL.Select(p => new Personel
        {
            ID = p.ID,
            PERSONEL = p.PERSONEL
        }).ToList();

        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult PostPersonel(Personel personel)
        {
            db.TBLPERSONEL.Add(new TBLPERSONEL
            {
                PERSONEL = personel.PERSONEL
            });
            db.SaveChanges();
            return Ok<string>("Personel Kaydedildi.");
        }

        public IHttpActionResult PutPersonel(int id)
        {
            TBLPERSONEL personel = db.TBLPERSONEL.FirstOrDefault(k => k.ID == id);
            personel.PERSONEL = " - Güncel";

            db.SaveChanges();
            return Ok<string>("Personel güncellenmiştir...");
        }

        [HttpPut]
        public IHttpActionResult PersonelGuncelle(int id, TBLPERSONEL p)
        {
            TBLPERSONEL personel = db.TBLPERSONEL.FirstOrDefault(k => k.ID == id);
            personel.PERSONEL =p.PERSONEL ;

            db.SaveChanges();

            return Ok<string>("Personel güncellenmiştir...");
        }


        public IEnumerable<Kitaplar> GetKitaplar() => db.TBLKITAP.Select(k => new Kitaplar
        {
            ID = k.ID,
            AD = k.AD,
            KATEGORI = k.KATEGORI,
            YAZAR = k.YAZAR,
            BASIMYIL = k.BASIMYIL,
            YAYINEVI = k.YAYINEVI,
            SAYFA = k.SAYFA
        }).ToList();

        [HttpGet]
        public Kitaplar KitapGetir(int id)
        {
            TBLKITAP k1 = db.TBLKITAP.FirstOrDefault(p => p.ID == id);

            return new Kitaplar
            {
                ID = k1.ID,
                AD = k1.AD,
                KATEGORI = k1.KATEGORI,
                YAZAR = k1.YAZAR,
                BASIMYIL = k1.BASIMYIL,
                YAYINEVI = k1.YAYINEVI,
                SAYFA = k1.SAYFA
            };
        }

        

    }
}
