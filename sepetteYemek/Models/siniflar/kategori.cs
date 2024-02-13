using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace sepetteYemek.Models.siniflar
{
    public class kategori
    {
        [Key]
        [Display(Name = "Kategori ID")]

        public int KategoriID { get; set; }
        [Display(Name = "Kategori Adı")]

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        //her kategorinin içerisinde birden fazla ürün vardır
        public ICollection<urunler> Uruns { get; set; }
    }
}