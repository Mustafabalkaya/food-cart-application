﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]

    public class satisController : Controller
    {

        // GET: satis
        context c =new context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        //[HttpGet]
        //public ActionResult YeniSatis()
        //{
        //    List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.UrunAd,
        //                                       Value = x.Urunid.ToString()
        //                                   }).ToList();
        //    List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.CariAd + " " + x.CariSoyad,
        //                                       Value = x.CariId.ToString()
        //                                   }).ToList();
        //    List<SelectListItem> deger3 = (from x in c.Personels.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.PersonelAd + " " + x.PersonelSoyad,
        //                                       Value = x.Personelid.ToString()
        //                                   }).ToList();
        //    ViewBag.dgr1 = deger1;
        //    ViewBag.dgr2 = deger2;
        //    ViewBag.dgr3 = deger3;
        //    return View();

        //}
        //[HttpPost]
        //public ActionResult YeniSatis(satisHareket s)
        //{
        //    s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    c.SatisHarekets.Add(s);
        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(satisHareket p)
        {
            var deger = c.SatisHarekets.Find(p.Satisid);
            deger.CariId = p.CariId;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.Personelid = p.Personelid;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.Urunid = p.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisDetay(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View(deger);
        }

    }
}