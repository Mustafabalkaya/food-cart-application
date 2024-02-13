using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace sepetteYemek.Models.siniflar
{
    public class context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<departman> Departmans { get; set; }
        public DbSet<faturaKalem> FaturaKalems { get; set; }
        public DbSet<faturalar> Faturalars { get; set; }
        public DbSet<gider> Giders { get; set; }
        public DbSet<kategori> Kategoris { get; set; }
        public DbSet<personel> Personels { get; set; }
        public DbSet<satisHareket> SatisHarekets { get; set; }
        public DbSet<urunler> Uruns { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<yapilacak> Yapilacaks { get; set; }
        public DbSet<KargoDetay> KargoDetays { get; set; }
        public DbSet<KargoTakip> KargoTakips { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
        public DbSet<Sepet> Sepets { get; set; }



        //public DbSet<detay> Detays { get; set; }
        //public DbSet<Yapilacak> Yapilacaks { get; set; }

        //public DbSet<mesajlar> mesajlars { get; set; }

    }

}