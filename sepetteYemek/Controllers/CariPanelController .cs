using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]

    public class CariPanelController : Controller
    {
        context c = new context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.Where(x => x.CariMail == mail).ToList();
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();
            return View(degerler);

        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesaj = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            ViewBag.d1 = gelensayisi;
            return View(mesaj);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesaj = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View(mesaj);
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(s => s.MesajID == id).ToList();

            var mail = (string)Session["CariMail"];
            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];

            var gidensayisi = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult LogOut()
        {

            //string cookiname = FormsAuthentication.FormsCookieName;
            //string ad = HttpContext.User.Identity.Name;
            //HttpCookie atc = HttpContext.Request.Cookies[cookiname];
            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(atc.Value);
            //string isim = ticket.Name;

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }

    }
}