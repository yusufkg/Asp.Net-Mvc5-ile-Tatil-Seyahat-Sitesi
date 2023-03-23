using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Proje.Models.Siniflar;

namespace Web_Proje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler =c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);//id degerini bul
            c.Blogs.Remove(b);//b'den gelen degeri sil
            c.SaveChanges();//degisiklikleri kaydet
            return RedirectToAction("Index");//tekrar indexe yönlendir
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.Tarih = b.Tarih;
            blg.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YorumListesi()
        {
            var yorunlar = c.Yorumlars.ToList();
            return View(yorunlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);//id degerini bul
            c.Yorumlars.Remove(b);//b'den gelen degeri sil
            c.SaveChanges();//degisiklikleri kaydet
            return RedirectToAction("YorumListesi");//tekrar indexe yönlendir
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }
    }
}
