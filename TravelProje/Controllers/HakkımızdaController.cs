using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class HakkımızdaController : Controller
    {

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Hakkımızdas.ToList();

            return View(degerler);
        }
    }
}