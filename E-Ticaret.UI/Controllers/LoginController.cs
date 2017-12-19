using E_Ticaret.BLL.DTO_s;
using E_Ticaret.UI.Models.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static E_Ticaret.BLL.BussinessManager;

namespace E_Ticaret.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel m)
        {
            try
            {
                KullaniciManager km = new KullaniciManager();
                KullaniciDTO kullaniciDTO = km.Denetle(m.kullanicilar.KullaniciAd, m.kullanicilar.Sifre);
                Session["Kullanici"] = kullaniciDTO.KullaniciAd;
                Session["Yetki"] = kullaniciDTO.Yetki;
                if (Session["Yetki"].ToString() == "Admin")
                {
                    return RedirectToAction("Admin", "Admin");
                }
                else if (Session["Yetki"].ToString() == "User")
                {
                    return RedirectToAction("Index", "Siparis");
                }
                else return RedirectToAction("Hata", "Login");
                //return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("Login", "Login");
            }

        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public ActionResult Hata()
        {

            return View();
        }
    }
}