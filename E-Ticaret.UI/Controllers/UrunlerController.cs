using E_Ticaret.ENT;
using E_Ticaret.REP;
using E_Ticaret.UI.Models.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static E_Ticaret.BLL.BussinessManager;

namespace E_Ticaret.UI.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        ETicaretEntities db = DBSingleTone.GetInstance();
        UrunManager um = new UrunManager();
        AltKategoriManager akm = new AltKategoriManager();
        [HttpGet]
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            UrunModel model = new UrunModel();
            model.ulist = um.GenelListe().ToList();
            model.aklist = db.AltKategori.Select(x => new AltKategoriSec { AltKategoriID = x.AltKategoriID, AltKategoriAd = x.AltKategoriAd }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Detay(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            Urunler urun = um.Bul(id);
            //var products = db.Products.Select(x => new
            //{
            //    x.ProductID,
            //    x.ProductName,
            //    x.QuantityPerUnit,
            //    x.UnitPrice,
            //    x.Discontinued
            //}).Where(x => x.ProductID == id).FirstOrDefault();
            return Json(urun, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Guncel(Urunler urun)
        {
            um.Guncelle(urun);
            um.Save();
            return Json(urun, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Ekle(Urunler urun)
        {
            if (ModelState.IsValid)
            {
                um.Ekle(urun);
                um.Save();
                return null;
            }
            else
            {
                return Json(ModelState.Keys.SelectMany(x => ModelState[x].Errors).Select(m => m.ErrorMessage).ToArray(), JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult Sil(int id)
        {
            Urunler urun = um.Bul(id);
            um.Sil(urun);
            um.Save();
            return Json(urun, JsonRequestBehavior.AllowGet);
        }
    }
}