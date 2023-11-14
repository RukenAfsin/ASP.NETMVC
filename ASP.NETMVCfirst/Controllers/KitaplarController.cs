using ASP.NETMVCfirst.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NETMVCfirst.Controllers
{
    public class KitaplarController : Controller
    {
        // GET: Kitaplar
        Entities db = new Entities();
        public ActionResult Index()
        {
            return View(db.KitaplarSets.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KitaplarSet kitaplar)
        {
            db.KitaplarSets.Add(kitaplar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var guncelle = db.KitaplarSets.Find(id);
            return View(guncelle);
        }
        [HttpPost]
        public ActionResult Edit(int id, KitaplarSet kitaplar)
        {
            db.Entry(kitaplar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var sil = db.KitaplarSets.Where(x => x.KitapNo == id).FirstOrDefault();
            return View(sil);
        }
        [HttpPost]
        public ActionResult Delete(int id, KitaplarSet kitaplar)
        {
            var sil = db.KitaplarSets.Where(x => x.KitapNo == id).FirstOrDefault();
            db.KitaplarSets.Remove(sil); db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}