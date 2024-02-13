using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]
    public class CarilerController : Controller
    {
        // GET: musteri
        context db = new context();
        public ActionResult Index()
        {
            var degerler = db.Carilers.Where(s => s.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        //[Authorize(Roles = "A")]

        public ActionResult YeniCari()
        {

            return View();
        }
        [HttpPost]

        public ActionResult YeniCari(Cariler cr)
        {
            cr.Durum = true;
            db.Carilers.Add(cr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = db.Carilers.Find(id);
            cr.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = db.Carilers.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cariler ca)
        {

            var cari = db.Carilers.Find(ca.CariId);
            cari.CariAd = ca.CariAd;
            cari.CariSoyad = ca.CariSoyad;
            cari.CariSehir = ca.CariSehir;
            cari.CariMail = ca.CariMail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musteriSatis(int id)
        {
            var satislar = db.SatisHarekets.Where(s => s.CariId == id).ToList();
            var cr = db.Carilers.Where(s => s.CariId == id).Select(b => b.CariAd + " " + b.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;

            return View(satislar);
        }
      
    }
}