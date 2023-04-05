using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class İletisimController : Controller
    {
        Context c = new Context();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index (İletisim iletisim) 
        { 
            c.İletisims.Add(iletisim);
            c.SaveChanges();
            
            
            return View();
        }
        
        
        
    }
}