using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.Take(10).ToList(); // TAKE(10) EKLEYEREK ANA SAYFADAKI RESIMLERDE 10 BLOG RESMI GOZUKSUN ISTEDIK//
            
            return View(degerler);
        }
        
        // Ana sayfadakı dolar yazan resımlerı bır partıal olarak aldık. sonra ana sayfaya ekleyecegız
         public PartialViewResult Partial1()
        {
          // tasarım olarak resımler yanyana degılde alt alta gelıyordu. son 2 blogu toplu olarak cekmıs olacagız
            var degerler =c.Blogs.OrderByDescending(x=> x.ID).Take(2).ToList();



            return PartialView(degerler);
        }

        public PartialViewResult Partial2()
        {

            var deger = c.Blogs.Take(3).ToList(); // Ana sayfada en begendıgım yerler bolumunde sol tarafta 3 tane gozuksun//



            return PartialView(deger);
        }

        public PartialViewResult Partial3()
        {

            var deger = c.Blogs.Take(3).OrderByDescending(x=> x.ID).ToList(); // Ana sayfada en begendıgım yerler bolumunde sag tarafta 3 tane gozuksun//



            return PartialView(deger);
        }

        public PartialViewResult Partial4() 
        { 
           var deger = c.Blogs.Where(x=> x.ID ==1).ToList();

            return PartialView(deger);
        }
    }
}