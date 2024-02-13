using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
using PagedList;
using PagedList.Mvc;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]

    public class kategoriController : Controller
    {
        // GET: kategori
        //işin back end tarafı controllerdir
        //birer metod yazılır.
        context c = new context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
         
        }
        [HttpGet]
        //[Authorize(Roles = "A")]

        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kt = c.Kategoris.Find(id);
            c.Kategoris.Remove(kt);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kt = c.Kategoris.Find(id);
            return View("KategoriGetir", kt);
        }
        public ActionResult KategoriGuncelle(kategori s)
        {
            var ktg = c.Kategoris.Find(s.KategoriID);
            ktg.KategoriAd = s.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Deneme()
        {
           cascading cs=new cascading();
            cs.Kategoriler = new SelectList(c.Kategoris, "KategoriID", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "Urunid", "UrunAd");
            return View(cs);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in c.Uruns
                               join y in c.Kategoris
                               on x.Kategori.KategoriID equals y.KategoriID
                               where x.Kategori.KategoriID == p
                               select new
                               {
                                   Text = x.UrunAd,
                                   Value=x.Urunid.ToString(),

                               });
            return Json(urunlistesi,JsonRequestBehavior.AllowGet);
        }
    }
}