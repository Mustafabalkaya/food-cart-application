using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sepetteYemek.Models.siniflar
{
    public class departman
    {

        [Key]
        public int Departmanid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        //bir departman birden fazla personelde bulunabilir
        public ICollection<personel> Personels { get; set; }
    }
}