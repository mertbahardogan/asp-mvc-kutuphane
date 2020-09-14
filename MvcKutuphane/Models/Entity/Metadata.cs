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


    public class TBLUYELERMetadata
    {
        [Required(ErrorMessage ="**Bu alan boş geçilemez.")]
        public string AD { get; set; }

        [Required(ErrorMessage = "**Bu alan boş geçilemez.")]
        public string SOYAD { get; set; }

        [Required(ErrorMessage = "**Parola alanı boş bırakılamaz.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "**\"{0}\" {2} karakter olmalıdır.", MinimumLength = 8)]
        public string SIFRE { get; set; }

        //[Required(ErrorMessage = "**Parola Tekrar alanı boş bırakılamaz.")]
        [Compare("SIFRE", ErrorMessage = "**Şifreler eşleşmiyor. Tekrar deneyin!")]
        [DataType(DataType.Password)]
        public string SIFREONAY { get; set; }

        [EmailAddress(ErrorMessage = "**Geçersiz mail adresi.")]
        public string MAIL { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "Lütfen sözleşmeyi kabul ediniz!")]
        //public Nullable<bool> SOZLESME { get; set; }
    }
}