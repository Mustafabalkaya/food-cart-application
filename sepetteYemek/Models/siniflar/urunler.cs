using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sepetteYemek.Models.siniflar
{
    public class urunler
    {
        [Key]
        public int Urunid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }

        public short Stok { get; set; }

        public decimal AlisFiyat { get; set; }

        public decimal SatisFiyat { get; set; }

        public bool Durum { get;  set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        public int Kategoriid { get; set; }
        public virtual kategori Kategori { get; set; }

        public ICollection<satisHareket> SatisHarekets { get; set; }

        // Yapıcı metot (constructor) üzerinden durum özelliğini ayarlayabiliriz
        public urunler()
        {
            Durum = true; // Yeni ürün eklenirken durum otomatik olarak true olarak atanır
        }

        // Stok durumuna göre durumu otomatik olarak güncelleyen metot
        public void StokDurumunuKontrolEt()
        {
            if (Stok == 0)
            {
                Durum = false; // Stok 0 ise durumu false olarak günceller
            }
            else
            {
                Durum = true; // Stok 0 değilse durumu true olarak günceller
            }
        }
        public virtual ICollection<Sepet> Sepet { get; set; }


    }
}