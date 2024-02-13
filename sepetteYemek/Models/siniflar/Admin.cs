using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sepetteYemek.Models.siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public string Rol { get; set; }

    }
}