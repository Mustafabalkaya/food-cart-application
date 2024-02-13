using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sepetteYemek.Models.siniflar
{
    public class Sepet
    {
        [Key]
        public int SepetId { get; set; }

        public int CariId { get; set; }
        public virtual Cariler Cari { get; set; }

        public int UrunId { get; set; }
        public virtual urunler Urun { get; set; }

        public int Miktar { get; set; }
        public decimal ToplamFiyat { get; set; }
    }
}