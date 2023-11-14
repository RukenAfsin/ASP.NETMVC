using ASP.NETMVCfirst.Models;
using System.Linq;
using System.Web.Mvc;

namespace ASP.NETMVCfirst.Controllers
{
    public class KullanıcılarController : Controller
    {
        // GET: Kullanıcılar
        Entities db = new Entities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KullanıcılarSet kullanıcı)
        {
            var kontrol = db.KullanıcılarSet.FirstOrDefault(x => x.AdSoyad == kullanıcı.AdSoyad && x.Sifre == kullanıcı.Sifre);
            if (kontrol != null)
            {

                return RedirectToAction("Create");
            }
            else
            {
                db.KullanıcılarSet.Add(kullanıcı);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}