using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSitem.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcSitem.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbStokEntities db = new DbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLMUSTERI.ToList().ToPagedList(sayfa,10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yenimusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenimusteri(TBLMUSTERI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("yenimusteri");
            }
            db.TBLMUSTERI.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil (int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERI.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBLMUSTERI p1)
        {
            var musteri = db.TBLMUSTERI.Find(p1.MUSTERI_ID);
            musteri.MUSTERİ_AD = p1.MUSTERİ_AD;
            musteri.MUSTERI_SOYAD = p1.MUSTERI_SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");


        }




    }
}