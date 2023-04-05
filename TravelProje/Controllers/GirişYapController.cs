using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;
using System.Web.Security;
namespace TravelProje.Controllers
{
    public class GirişYapController : Controller
    {
       Context c = new Context();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin) 
        { 
            // kullanıcı  adı  sifre kontrol kodu
            var bilgiler = c.Admins.FirstOrDefault(x=> x.Kullanici ==admin.Kullanici && x.Sifre == admin.Sifre);

            // EGER BILGILER DOGRU İSE
            if (bilgiler != null) 
            {  
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();

                return RedirectToAction("Index" , "Admin");
            }
            else 
            { 
                return View(); 
            }
        }

        public ActionResult Logout() 
        
        {
         FormsAuthentication.SignOut();

            return RedirectToAction("Login" , "GirişYap");
        
        }

    }
}