using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]

    public class personelController : Controller
    {
        // GET: personel
        context c=new context();
        public ActionResult Index(string p)
        {
            var degerler = from x in c.Personels select x;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(y => y.PersonelAd.Contains(p));

            }
            return View(degerler.ToList());
        }
        [HttpGet]
        //[Authorize(Roles = "A")]

        public ActionResult personelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()

                                           }).ToList();
            ViewBag.x = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult personelEkle(personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var kt = c.Personels.Find(id);
            c.Personels.Remove(kt);
            c.SaveChanges();
            return RedirectToAction("Index","Personel");
        }
        public ActionResult personelGetir(int id)
        {
            List<SelectListItem> deger2 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger2;

            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);

        }
        public ActionResult PersonelGuncelle(personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            var prs = c.Personels.Find(p.Personelid);
            prs.PersonelAd = p.PersonelAd;
            prs.PersonelSoyad = p.PersonelSoyad;
            prs.PersonelGorsel = p.PersonelGorsel;
            prs.departmanid = p.departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}