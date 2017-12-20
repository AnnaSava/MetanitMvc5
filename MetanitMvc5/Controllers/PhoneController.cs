using MetanitMvc5.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MetanitMvc5.Controllers
{
    public class PhoneController : Controller
    {
        private Mvc5Context db = new Mvc5Context();
        private AppCache appCache;

        public PhoneController()
        {
            appCache = new AppCache();
        }
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = appCache.GetValue(id.Value);
            // если нет в кэше
            if (result == null)
            {
                // берем из БД
                result = db.Phones.Find(id);
                // добавляем в кэш
                appCache.Add(result);
            }

            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        public string Init()
        {
            if (db.Phones.Any()) return "Already initialized";

            db.Phones.Add(new Phone()
            {
                Name = "Siemens C60"
            });
            db.Phones.Add(new Phone()
            {
                Name = "Sony Ericsson k550i"
            });
            db.Phones.Add(new Phone()
            {
                Name = "HTC Incredible S"
            });
            db.Phones.Add(new Phone()
            {
                Name = "Samsung B350E"
            });
            db.Phones.Add(new Phone()
            {
                Name = "Xiaomi Redmi 4"
            });
            db.SaveChanges();
            return "Phones added";
        }
    }
}