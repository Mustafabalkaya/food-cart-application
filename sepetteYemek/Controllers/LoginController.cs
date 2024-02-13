using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using sepetteYemek.Models.siniflar;
namespace sepetteYemek.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        context c = new context();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminLogin(Admin p)
        {
            context model = new context();

            Admin u = model.Admins.FirstOrDefault(x => x.KullaniciAd == p.KullaniciAd && x.Sifre == p.Sifre);

            if (u == null)
            {
                ViewBag.hata = "Kullanıcı Adı veya Kullanıcı Şifre Hatalı!";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(u.KullaniciAd, false);
                return RedirectToAction("Index", "urun");
            }
        }
        public ActionResult LogOut()
        {

            //string cookiname = FormsAuthentication.FormsCookieName;
            //string ad = HttpContext.User.Identity.Name;
            //HttpCookie atc = HttpContext.Request.Cookies[cookiname];
            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(atc.Value);
            //string isim = ticket.Name;

            FormsAuthentication.SignOut();

            return RedirectToAction("Index","Login");
        }

        public ActionResult Hata()
        {
            return View();
        }

    }
}