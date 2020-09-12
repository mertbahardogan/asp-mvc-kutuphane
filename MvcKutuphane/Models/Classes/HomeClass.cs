using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace MvcKutuphane.Models.Classes
{
    public class HomeClass
    {
        public IEnumerable<TBLILETISIM> DegerX { get; set; }
        public IEnumerable<TBLHAREKET> DegerY { get; set; }

    }
}