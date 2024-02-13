using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sepetteYemek.Models.siniflar
{
    public class faturalar
    {
        [Key]
        public int Faturaid { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]

        public string FaturaSiraNo { get; set; }

        public DateTime Tarih { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        //bir faturanın birden fazla kalemi olabilir
        public decimal Toplam { get; set; }
        public ICollection<faturaKalem> FaturaKalems { get; set; }

    }
}