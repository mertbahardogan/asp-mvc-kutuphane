using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKutuphane.Models.Entity
{
    public class Kitaplar
    {
        public int ID { get; set; }
        public string AD { get; set; }
        public Nullable<byte> KATEGORI { get; set; }
        public Nullable<int> YAZAR { get; set; }
        public string BASIMYIL { get; set; }
        public string YAYINEVI { get; set; }
        public string SAYFA { get; set; }
    }
}