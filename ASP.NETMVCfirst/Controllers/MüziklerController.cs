using ASP.NETMVCfirst.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NETMVCfirst.Controllers
{
    public class MüziklerController : Controller
    {
        // GET: Müzikler
        Entities db = new Entities();
        public ActionResult Index()
        {
            return View(db.MüziklerSet.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MüziklerSet müzikler)
        {
            db.MüziklerSet.Add(müzikler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var guncelle = db.MüziklerSet.Find(id);
            return View(guncelle);
        }
        [HttpPost]
        public ActionResult Edit(int id, MüziklerSet müzikler)
        {
            db.Entry(müzikler).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var sil = db.MüziklerSet.Find(id);
            return View(sil);
        }
        [HttpPost]
        public ActionResult Delete(int id, MüziklerSet mzikler)
        {
            var sil = db.MüziklerSet.Find(id);
            db.MüziklerSet.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}