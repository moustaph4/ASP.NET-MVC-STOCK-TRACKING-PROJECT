using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;

using StokTakipProjesi.Models.Entity;


namespace StokTakipProjesi.Controllers
{
    public class MusteriController : Controller
    {

        dbMvcStokEntities1 database = new dbMvcStokEntities1 ();

        // GET: Musteri
        public ActionResult Index(int sayfa = 1 ,string arama = "")
        {
            var degerler = from d in database.tblMusteri select d;

            if (!string.IsNullOrEmpty(arama))
            {
                degerler = degerler.Where(m => m.musteriAd.Contains(arama));

                return View(degerler.ToList().ToPagedList(sayfa, 50));
            }

            return View(degerler.ToList().ToPagedList(sayfa, 4));

            //var degerler = database.tblMusteri.ToList().ToPagedList(sayfa, 4);

            //return View(degerler);
        }

        [HttpGet]
        public ActionResult Yenimusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenimusteri(tblMusteri ekle) 
        {
            if (!ModelState.IsValid)
            {
                return View("Yenimusteri");
            }

            database.tblMusteri.Add(ekle);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Silmusteri(int id)
        {
            var musteri = database.tblMusteri.SingleOrDefault(m => m.musteriId == id);
            database.tblMusteri.Remove(musteri);
            database.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Getirmusteri (int id) 
        {

            var musteri = database.tblMusteri.SingleOrDefault(m => m.musteriId == id);

            return View("Getirmusteri", musteri);   
        
        }

        public ActionResult Guncellemusteri (tblMusteri guncelle)
        {

            var musteri = database.tblMusteri.Find(guncelle.musteriId);
            musteri.musteriAd = guncelle.musteriAd;
            musteri.musteriSoyad = guncelle.musteriSoyad;
            database.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}