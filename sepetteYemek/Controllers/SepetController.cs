using sepetteYemek.Models.siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sepetteYemek.Controllers
{
    [AllowAnonymous]

    public class SepetController : Controller
    {
        // GET: Sepet
        context c= new context();
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Sepets.Where(x => x.Cari.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = c.Sepets.Where(x => x.CariId == id).ToList();
            return View(degerler);
        }
    }
}