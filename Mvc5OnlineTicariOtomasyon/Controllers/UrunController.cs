using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {

        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.Urunad.Contains(p));
            }
            return View(urunler.ToList());
        }

        //Bu kısım dropdown kısmı
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> kategoriler = (from x in c.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            ViewBag.ktgr = kategoriler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            u.Durum = true;
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urn = c.Uruns.Find(id);
            urn.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kategoriler = (from x in c.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            ViewBag.ktgr = kategoriler;

            var urn = c.Uruns.Find(id);
            return View("UrunGetir", urn);
        }

        public ActionResult UrunGuncelle(Urun u)
        {

            var urn = c.Uruns.Find(u.Urunid);
            urn.Urunad = u.Urunad;
            urn.Marka = u.Marka;
            urn.Stok = u.Stok;
            urn.AlisFiyat = u.AlisFiyat;
            urn.SatisFiyat = u.SatisFiyat;
            urn.Durum = true;
            urn.UrunGorsel = u.UrunGorsel;
            urn.Kategoriid = u.Kategoriid;

            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var urunler = c.Uruns.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            List<SelectListItem> deger4 = (from y in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CariAd + " " + y.CariSoyad,
                                               Value = y.Cariid.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            var deger1 = c.Uruns.Find(id);

            ViewBag.dgr1 = deger1.Urunid;
            ViewBag.dgr2 = deger1.SatisFiyat;

            return View();

        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }

    }
}
