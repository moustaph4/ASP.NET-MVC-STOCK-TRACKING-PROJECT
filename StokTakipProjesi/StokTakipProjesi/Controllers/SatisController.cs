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
    public class SatisController : Controller
    {

        dbMvcStokEntities1 database = new dbMvcStokEntities1();

        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Yenisatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yenisatis(tblSatis ekle)
        {
            database.tblSatis.Add(ekle);
            database.SaveChanges();
            return View("Index");
        }
    }
}