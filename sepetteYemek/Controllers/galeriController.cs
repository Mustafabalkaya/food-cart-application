using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]
    public class galeriController : Controller
    {
        // GET: galeri
        context c = new context();
        public ActionResult Index()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}