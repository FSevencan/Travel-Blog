using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData.ModelProviders;
using System.Web.Mvc;
using System.Web.Services.Description;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    [Authorize] // SADECE LOGİN OLANLAR GOREBİLİR.
    public class AdminController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();


            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {

            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog( Blog blog)
        {
            
            if (ModelState.IsValid)
            {
                c.Blogs.Add(blog); 
                c.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bg = c.Blogs.Find(id);


            return View("BlogGetir", bg);
        }

        public ActionResult BlogGuncelle(Blog blog)
        {
            var blg = c.Blogs.Find(blog.ID);  
            blg.Aciklama = blog.Aciklama;
            blg.Baslik = blog.Baslik;
            blg.BlogImage = blog.BlogImage;
            blg.Tarih = blog.Tarih;
            c.SaveChanges(); 


            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi() 
        { 
            var yorumlar =c.Yorumlars.OrderByDescending(x=>x.ID).ToList(); // YORUM ID SINE GORE EN SON YORUM YUKARIDA OLUCAK SEKILDE SIRALADIM
            
            return View(yorumlar); 
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();

            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);


            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var yrm = c.Yorumlars.Find(yorumlar.ID);  
            yrm.KullaniciAdi = yorumlar.KullaniciAdi;
            yrm.Mail = yorumlar.Mail;
            yrm.Yorum = yorumlar.Yorum;
            c.SaveChanges(); 


            return RedirectToAction("YorumListesi");
        }

        

        public ActionResult Hakkımızda()
        {
            return View();
        }

        public ActionResult HakkımızdaListesi()
        {
            var hk = c.Hakkımızdas.ToList(); 

            return View(hk);
        }
        public ActionResult HakkımızdaGetir(int id)
        {
            var hk = c.Hakkımızdas.Find(id);


            return View("HakkımızdaGetir", hk);
        }
        [HttpPost]
        public ActionResult HakkımızdaGuncelle(Hakkımızda hakkımızda)
        {
            var hkm = c.Hakkımızdas.Find(hakkımızda.ID);  
            
            hkm.Aciklama = hakkımızda.Aciklama;
            hkm.FotoUrl = hakkımızda.FotoUrl;

            c.SaveChanges(); 


            return RedirectToAction("HakkımızdaListesi");
        }

        public ActionResult İletisimListesi()
        {
            var mesajlar = c.İletisims.OrderByDescending(x => x.ID).ToList(); // Mesaj ID SINE GORE EN SON YORUM YUKARIDA OLUCAK SEKILDE SIRALADIM

            return View(mesajlar);
        }

        public ActionResult MesajSil(int id)
        {
            var b = c.İletisims.Find(id);
            c.İletisims.Remove(b);
            c.SaveChanges();

            return RedirectToAction("İletisimListesi");
        }


    }
}

