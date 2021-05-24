using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSitem.Models.Entity;


namespace MvcSitem.Controllers
{
    public class SatısController : Controller
    {
        DbStokEntities db = new DbStokEntities();
        // GET: Satıs
        public ActionResult Index()
        {
            var degerler = db.TBLSATISLAR.ToList();
            ViewBag.tablo = degerler;
            return View();
        }
        [HttpGet]
        public ActionResult Yenisatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yenisatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}