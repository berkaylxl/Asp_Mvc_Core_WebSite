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
    public class UrunController : Controller
    {
        // GET: Urun
        DbStokEntities db = new DbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            
            var degerler = db.TBLURUNLER.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yeniurun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİ_AD,
                                                 Value = i.KATEGORI_ID.ToString()
                                             }
                                           ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult yeniurun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORİLER.Where(m => m.KATEGORI_ID == p1.TBLKATEGORİLER.KATEGORI_ID).FirstOrDefault();
            p1.TBLKATEGORİLER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult urungetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİ_AD,
                                                 Value = i.KATEGORI_ID.ToString()
                                             }
                                          ).ToList();
            ViewBag.dgr = degerler;
            return View("urungetir", urun);
        }
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urun = db.TBLURUNLER.Find(p1.URUN_ID);
            urun.URUN_AD = p1.URUN_AD;
            urun.STOK = p1.STOK;
            urun.MARKA = p1.MARKA;
            var ktg = db.TBLKATEGORİLER.Where(m => m.KATEGORI_ID == p1.TBLKATEGORİLER.KATEGORI_ID).FirstOrDefault();
            urun.URUN_KATEGORİ = ktg.KATEGORI_ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}