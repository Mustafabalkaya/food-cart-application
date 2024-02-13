using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;

namespace sepetteYemek.Controllers
{
    [AllowAnonymous]
    
    public class yapilacakController : Controller
    {
        context c = new context();

        public ActionResult Index()
        {
           
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.dgr2 = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.dgr3 = deger3;
            

            var yapilacaklar = c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
        
    }
}