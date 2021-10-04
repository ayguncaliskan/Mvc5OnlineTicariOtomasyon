using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index()
        {
            UrunDetay ud = new UrunDetay();
            //var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            ud.Deger1 = c.Uruns.Where(x => x.Urunid == 1).ToList();
            ud.Deger2 = c.Detays.Where(y => y.DetayID == 1).ToList();
            return View(ud);

        }
    }
}