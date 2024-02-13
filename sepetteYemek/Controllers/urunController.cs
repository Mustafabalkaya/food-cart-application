using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using sepetteYemek.Models.siniflar;
using sepetteYemek.Security;

namespace sepetteYemek.Controllers
{
    public class urunController : Controller
    {
        
        // GET: urun
        context c = new context();
        public ActionResult Index(string p)
        {
            var degerler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(y => y.UrunAd.Contains(p));


            }
            return View(degerler.Where(x => x.Durum == true).ToList());


        }
        [HttpGet]

        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()

                                           }).ToList();
            ViewBag.x = deger1;

            return View();
        }
        [HttpPost]

        public ActionResult YeniUrun(urunler p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.UrunGorsel = "/Image/" + dosyaadi + uzanti;
            }
            p.Durum = true;
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            //sb.Uruns.Remove(deger);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from sb in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = sb.KategoriAd,
                                               Value = sb.KategoriID.ToString()

                                           }).ToList();
            ViewBag.sb = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }

        public ActionResult UrunGuncelle(urunler p)
        {
            var urn = c.Uruns.Find(p.Urunid);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            var urun = c.Uruns.Find(id);
            ViewBag.dgr1 = urun.Urunid;
            ViewBag.dgr2 = urun.SatisFiyat;           

            // Diğer gerekli verileri hazırla ve görünüme gönder
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            List<SelectListItem> deger4 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;

            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(satisHareket p)
        {
            p.Tarih = DateTime.Now;
            c.SatisHarekets.Add(p);
            c.SaveChanges();

            // Ürün satışını yapıldıktan sonra sepete ekleme işlemleri
            var yeniSepetItem = new Sepet
            {
                CariId = p.CariId,
                UrunId = p.Urunid,
                Miktar = p.Adet,
                ToplamFiyat = p.ToplamTutar
            };

            c.Sepets.Add(yeniSepetItem);
            c.SaveChanges();

            return RedirectToAction("Index", "Satis");
        }
        public ActionResult stok_kontrol()
        {
            context c = new context(); 
            List<urunler> stoktakiUrunler = new List<urunler>();
            stoktakiUrunler = c.Uruns.SqlQuery("EXEC stok_goruntule").ToList();
            return View(stoktakiUrunler);
        }
        
    }
}