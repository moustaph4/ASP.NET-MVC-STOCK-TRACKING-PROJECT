using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;

//model klasörünü import ettik

using StokTakipProjesi.Models.Entity;

//-----------------------------------------------------

namespace StokTakipProjesi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        //modelin içindeki veritabanı tablolarını kullanabilmek için nesne ürettik.

        //amacımız kategorileri listelemek

        dbMvcStokEntities1 database = new dbMvcStokEntities1();

        public ActionResult Index(int sayfa = 1, string arama = "")
        {
            var degerler = from d in database.tblKategori select d;

            if (!string.IsNullOrEmpty(arama))
            {
                degerler = degerler.Where(m => m.kategoriAd.Contains(arama));

                return View(degerler.ToList().ToPagedList(sayfa, 50));
            }

            return View(degerler.ToList().ToPagedList(sayfa, 4));

            //var degerler = database.tblMusteri.ToList().ToPagedList(sayfa, 4);

            //return View(degerler);
        }


        [HttpGet] // Sayfa üzerinde işlem yapılmazsa HTTPGET çalıştır ve sadece sayfayı getir.
        public ActionResult Yenikategori()
        {
            return View();
        }

        [HttpPost] // Sayfa üzerinde işlem yapılırsa HTTPPOST çalıştır ve işlemleri yapıp sayfayı getir.
        public ActionResult Yenikategori(tblKategori ekle) 
        {
            if (!ModelState.IsValid)
            {
                return View("Yenikategori");
            }

            database.tblKategori.Add(ekle);
            database.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Silkategori(int id) 
        {
            var kategori = database.tblKategori.SingleOrDefault(m => m.kategoriId == id);
            database.tblKategori.Remove(kategori);
            database.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Getirkategori(int id)
        {
            var kategori = database.tblKategori.SingleOrDefault(m => m.kategoriId == id);

            return View("Getirkategori", kategori);  

        }

        public ActionResult Guncellekategori(tblKategori guncelle)
        {
            var kategori = database.tblKategori.Find(guncelle.kategoriId);
            kategori.kategoriAd = guncelle.kategoriAd;
            database.SaveChanges();
            return RedirectToAction("Index");   

        }
    }
}