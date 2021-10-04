using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori-Ürün stok sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "{Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 77 }).Write();

            return File(grafikciz.ToWebImage().GetBytes(),"image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.Urunad));
            sonuclar.ToList().ForEach(x => yvalue.Add(x.Stok));
            var grafik = new Chart(width: 500, height: 500)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        } public ActionResult VisualizeUrunResult2()
        {
            return Json(Urunlistesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif2> Urunlistesi2()
        {
            List<Sinif2> snf = new List<Sinif2>();
            using (var context=new Context())
            {
                snf = c.Uruns.Select(x => new Sinif2
                {
                    urn = x.Urunad,
                    stk = x.Stok
                }).ToList();
            }
                return snf;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public List<Sinif1> Urunlistesi()
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1(){
                urunad="Bigisayar",
                stok = 120
            });
            snf.Add(new Sinif1()
            {
                urunad = "Çamaşır Makinesi",
                stok = 150
            });
            snf.Add(new Sinif1()
            {
                urunad = "Mobilya",
                stok = 100
            });
            snf.Add(new Sinif1()
            {
                urunad = "Televizyon",
                stok = 75
            });
            snf.Add(new Sinif1()
            {
                urunad = "Tablet",
                stok = 134
            });
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        } public ActionResult Index7()
        {
            return View();
        }
    }
}