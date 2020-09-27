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
    }


    //public IEnumerable<TBLKITAP> GetKitaplarOn()
    //{
    //    return db.TBLKITAP.Where(x => x.DURUM == true).ToList();
    //}


}
