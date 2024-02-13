using sepetteYemek.Models.siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Security;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]
    public class KargoController : Controller
    {
        // GET: Kargo
        context c = new context();
        public ActionResult Index(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargo = kargo.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargo.ToList());
        }
        [HttpGet]
        [MyAuthorization(Roles = "A")]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] Karakter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z" };
            int k1, k2, k3;
            k1 = rnd.Next(0, Karakter.Length);
            k2 = rnd.Next(0, Karakter.Length);
            k3 = rnd.Next(0, Karakter.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kontrol = s1.ToString() + Karakter[k1] + s2 + Karakter[k2] + s3 + Karakter[k3];
            ViewBag.takipkodu = kontrol;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}