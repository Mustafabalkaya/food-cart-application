using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace sepetteYemek.Models.siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Gonderici { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alici { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }
      
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Icerik { get; set; }
        
        [Column(TypeName = "SmallDateTime")]
        public DateTime Tarih { get; set; }
    }
}