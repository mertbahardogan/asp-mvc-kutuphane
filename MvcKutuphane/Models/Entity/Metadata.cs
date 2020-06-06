using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcKutuphane.Models.Entity
{
    public class TBLPERSONELMetadata
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [Display(Name = "Personel Adı")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Bu alanın uzunluğu 5-50 karakter arasında olabilir.")]
        public string PERSONEL { get; set; }
    }

    public class TBLKATEGORIMetadata
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [Display(Name = "Kategori Adı")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Bu alanın uzunluğu 2-20 karakter arasında olabilir.")]
        public string AD { get; set; }
    }


}