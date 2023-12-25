using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Sınıflar;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        //burada 2 tane aynı isimde actionresult tanımladık.
        //biri http get de çalışacak,
        //yani sayfa yüklendiğinde hiçbir sey yapma, sadece sayfanın boş halini döndür.
        [HttpGet]
        public ActionResult YeniBlog() 
        {
            return View();
        }
        //post işlemi yapıldığında ise bu actionresultı çalıştırır.
        [HttpPost]  
        public ActionResult YeniBlog(Blog p) 
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.BlogImage = "/Image/" + dosyaadi + uzanti;
            }
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int? id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama=b.Aciklama;
            blg.Baslik=b.Baslik;
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                b.BlogImage = "/Image/" + dosyaadi + uzanti;
            }
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

        public ActionResult YorumGetir(int? id)
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

        public ActionResult iletisimListesi()
        {
            var il = c.Iletisims.ToList();
            return View(il);

        }
        public ActionResult iletisimSil(int id)
        {
            var il = c.Iletisims.Find(id);
            c.Iletisims.Remove(il);
            c.SaveChanges();
            return RedirectToAction("iletisimListesi");
        }

        public ActionResult iletisimGetir(Iletisim i)
        {
            var il = c.Iletisims.Find(i.ID);
            il.AdSoyad = i.AdSoyad;
            il.Mail = i.Mail;
            il.Konu = i.Konu;
            il.Mesaj = i.Mesaj;
            c.SaveChanges();
            return RedirectToAction("iletisimListesi");
        }

        //---------------------------------------------------------
        public ActionResult HakkimizdaListesi()
        {
            var hakkimizda = c.Hakkimizdas.ToList();
            return View(hakkimizda);
        }

        public ActionResult HakkimizdaSil(int id)
        {
            var h = c.Hakkimizdas.Find(id);
            c.Hakkimizdas.Remove(h);
            c.SaveChanges();
            return RedirectToAction("HakkimizdaListesi");
        }

        public ActionResult HakkimizdaGetir(int? id)
        {
            var hk = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", hk);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hk = c.Hakkimizdas.Find(h.ID);
           
            hk.Aciklama = h.Aciklama;
            hk.FotoUrl = h.FotoUrl;
            //if (Request.Files.Count > 0)
            //{
            //    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
            //    string uzanti = Path.GetExtension(Request.Files[0].FileName);
            //    string yol = "~/Image/" + dosyaadi + uzanti;
            //    Request.Files[0].SaveAs(Server.MapPath(yol));
            //    b.BlogImage = "/Image/" + dosyaadi + uzanti;
            //}
            //blg.BlogImage = b.BlogImage;
            //blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("HakkimizdaListesi");
        }


        //public ActionResult iletisimGuncelle(Iletisim mesaj)
        //{
        //    var il = c.Iletisims.Find(mesaj.ID);
        //    il.AdSoyad = mesaj.AdSoyad;
        //    il.Mail = mesaj.Mail; 
        //    il.Konu = mesaj.Konu;
        //    il.Mesaj = mesaj.Mesaj;
        //    c.SaveChanges();
        //    return RedirectToAction("iletisimListesi");
        //}


    }
}