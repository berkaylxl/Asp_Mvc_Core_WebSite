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
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbStokEntities db = new DbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.TBLKATEGORİLER.ToList();
            var degerler = db.TBLKATEGORİLER.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yenikategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenikategori(TBLKATEGORİLER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("yenikategori");
            }
                db.TBLKATEGORİLER.Add(p1);
                db.SaveChanges();
               return View();
        }
        public ActionResult Sil (int id)
        {
            var kategori = db.TBLKATEGORİLER.Find(id);
            db.TBLKATEGORİLER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORİLER p1)
        {
            var ktgr = db.TBLKATEGORİLER.Find(p1.KATEGORI_ID);
            ktgr.KATEGORİ_AD = p1.KATEGORİ_AD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}