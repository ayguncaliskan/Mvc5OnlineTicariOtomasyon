using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
       
        Context c = new Context();
        public ActionResult Index()
        {
            var satislar = c.SatisHarekets.ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Urunad,
                                                Value = x.Urunid.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.Cariid.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.Personelid.ToString()
                                                }).ToList();
            ViewBag.urun = urunler;
            ViewBag.cari = cariler;
            ViewBag.personel = personeller;

            return View();
        }
        [HttpPost]
        public ActionResult SatisEkle(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            var satis = c.SatisHarekets.Find(id);

            List<SelectListItem> urunler = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Urunad,
                                                Value = x.Urunid.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in c.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.Cariid.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in c.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.Personelid.ToString()
                                                }).ToList();
            ViewBag.urun = urunler;
            ViewBag.cari = cariler;
            ViewBag.personel = personeller;


            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var sts = c.SatisHarekets.Find(s.Satisid);

            sts.Cariid = s.Cariid;
            sts.Personelid = s.Personelid;
            sts.Urunid = s.Urunid;
            sts.Adet = s.Adet;
            sts.Fiyat = s.Fiyat;
            sts.ToplamTutar = s.ToplamTutar;

            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var satis = c.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View(satis);
        }

        public ActionResult SatisListesi()
        {
            var satislar = c.SatisHarekets.ToList();
            return View(satislar);
        }
    }
}
