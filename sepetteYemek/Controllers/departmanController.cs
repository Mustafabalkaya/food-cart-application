using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]

    public class departmanController : Controller
    {
        // GET: departman
        context sb=new context();

        public ActionResult Index()
        {
            var degerler = sb.Departmans.Where(s => s.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]

        public ActionResult DepartmanEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(departman d)
        {
            d.Durum = true;
            sb.Departmans.Add(d);
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dp = sb.Departmans.Find(id);
            dp.Durum = false;
            sb.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = sb.Departmans.Find(id);

            return View("DepartmanGetir", dpt);
        }
        public ActionResult DepartmanGuncelle(departman s)
        {
            var dep = sb.Departmans.Find(s.Departmanid);
            dep.DepartmanAd = s.DepartmanAd;
            sb.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = sb.Personels.Where(s => s.departmanid == id).ToList();
            var dpt = sb.Departmans.Where(s => s.Departmanid == id).Select(b => b.DepartmanAd).FirstOrDefault();
            ViewBag.s = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = sb.SatisHarekets.Where(s => s.Personelid == id).ToList();
            var per = sb.Personels.Where(s => s.Personelid == id).Select(b => b.PersonelAd + " " + b.PersonelSoyad).FirstOrDefault();
            ViewBag.dp = per;
            return View(degerler);
        }
    }
}