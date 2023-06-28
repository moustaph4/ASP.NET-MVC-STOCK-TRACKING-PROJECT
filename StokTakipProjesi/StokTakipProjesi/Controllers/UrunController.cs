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
    public class UrunController : Controller
    {
        // GET: Urun

        dbMvcStokEntities1 database = new dbMvcStokEntities1();
        public ActionResult Index(int sayfa = 1, string arama = "")
        {
            var degerler = from d in database.tblUrun select d;

            if (!string.IsNullOrEmpty(arama))
            {
                degerler = degerler.Where(m => m.urunAd.Contains(arama));

                return View(degerler.ToList().ToPagedList(sayfa, 50));
            }

            return View(degerler.ToList().ToPagedList(sayfa, 4));

            //var degerler = database.tblMusteri.ToList().ToPagedList(sayfa, 4);

            //return View(degerler);
        }

        [HttpGet]

        public ActionResult Yeniurun()
        {
            List<SelectListItem> degerler = (from i in database.tblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriId.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]

        public ActionResult Yeniurun(tblUrun ekle)
        {
            var kategori = database.tblKategori.Where(m => m.kategoriId == ekle.tblKategori.kategoriId).FirstOrDefault();
            ekle.tblKategori = kategori;

            database.tblUrun.Add(ekle);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Silurun (int id)
        {
            var urun = database.tblUrun.SingleOrDefault(m => m.urunId == id);
            database.tblUrun.Remove(urun);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getirurun(int id)
        {
            var kategori = database.tblUrun.SingleOrDefault(m => m.urunId == id);

            List<SelectListItem> degerler = (from i in database.tblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriId.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;

            return View("Getirurun", kategori);

        }

        public ActionResult Guncelleurun(tblUrun p)
        {
            var urun = database.tblUrun.Find(p.urunId);

            urun.urunAd = p.urunAd;
            urun.urunStok = p.urunStok;
            urun.urunMarka= p.urunMarka;    
            urun.urunFiyat= p.urunFiyat;
            
            var kategori = database.tblKategori.Where(m => m.kategoriId == p.tblKategori.kategoriId).FirstOrDefault();

            urun.urunKategori = kategori.kategoriId;

            database.SaveChanges(); 

            return RedirectToAction("Index");



        }

        
    }
}