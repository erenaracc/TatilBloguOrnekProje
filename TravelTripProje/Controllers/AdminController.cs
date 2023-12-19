using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;
using TravelTripProje.Controllers;

namespace TravelTripProje.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]

        public ActionResult Index()
        {
            var degeler=c.Blogs.ToList();
            return View(degeler);
        }
        [HttpGet]

        public ActionResult YeniBlog()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p )
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil (int id)
        {
            var b =c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir (int id)
        {
            var bl=c.Blogs.Find(id);
            return View("BlogGetir",bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.Id);
            blg.Aciklama= b.Aciklama;
            blg.Baslik=b.Baslik;
            blg.BlogImage=b.BlogImage;
            blg.Tarih=b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir (int id)
        {
            var yr=c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.Id);
            yrm.KullaniciAdi= y.KullaniciAdi;  
            yrm.Yorum=y.Yorum;
            yrm.Mail=y.Mail;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}