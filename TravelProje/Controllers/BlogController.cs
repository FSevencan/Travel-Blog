using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            
            by.Deger1 =c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(5).ToList();
            return View(by);
        }
      
        public ActionResult BlogDetay(int id)
        {
           by.Deger1 = c.Blogs.Where(x=> x.ID== id).ToList();
           by.Deger2=c.Yorumlars.Where(x=> x.Blogid== id).ToList();
      
           

            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            
            ViewBag.deger = id;

            return PartialView();
        }


        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yorumlar) 
        {
          c.Yorumlars.Add(yorumlar);
          c.SaveChanges();
          
           
            return PartialView();
        }

    }
}