using ASP.NETMVCfirst.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NETMVCfirst.Controllers
{
    public class ElektroniklerController : Controller
    {
        // GET: Elektronikler
        Entities db = new Entities();
        [Authorize]
        public ActionResult Index()
        {
            return View(db.ElektroniklerSets.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ElektroniklerSet elektronikler)
        {
            db.ElektroniklerSets.Add(elektronikler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var guncelle = db.ElektroniklerSets.Where(x => x.ENo == id).FirstOrDefault();
            return View(guncelle);
        }
        [HttpPost]
        public ActionResult Edit(int id, ElektroniklerSet elektronikler)
        {
            db.Entry(elektronikler).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var sil = db.ElektroniklerSets.Where(x => x.ENo == id).FirstOrDefault();
            return View(sil);
        }
        [HttpPost]
        public ActionResult Delete(int id, ElektroniklerSet elektronikler)
        {
            var sil = db.ElektroniklerSets.Where(x => x.ENo == id).FirstOrDefault();
            db.ElektroniklerSets.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}