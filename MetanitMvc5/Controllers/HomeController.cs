using MetanitMvc5.Annotations;
using MetanitMvc5.Filters;
using MetanitMvc5.Models;
using MetanitMvc5.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetanitMvc5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string TriangleSquare(int a, int h)
        {
            double s = a * h / 2.0;
            return "<h2>Площадь треугольника с основанием " + a +
                    " и высотой " + h + " равна " + s + "</h2>";
        }

        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int b = Int32.Parse(Request.Params["b"]);
            int s = a * b;
            return "<h2>Площадь прямоугольника со сторонами " + a + " и " + b + " равна " + s + "</h2>";
        }

        public ActionResult CustomActionResult()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        public ActionResult ImageResult()
        {
            string path = "../Images/panda.png";
            return new ImageResult(path);
        }

        public ActionResult StatusCode404(int age)
        {
            if (age < 21)
            {
                return new HttpStatusCodeResult(404);
            }
            return View();
        }

        public ActionResult NotFound(int age)
        {
            if (age < 21)
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Unauthorized(int age)
        {
            if (age < 21)
            {
                return new HttpUnauthorizedResult();
            }
            return View();
        }

        // Отправка файла
        public FileResult GetFile()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Images/panda.png");
            // Тип файла - content-type
            string file_type = "image/png";
            // Имя файла - необязательно
            string file_name = "panda.png";
            return File(file_path, file_type, file_name);
        }

        // Отправка массива байтов
        public FileResult GetBytes()
        {
            string path = Server.MapPath("~/Images/panda.png");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "image/png";
            string file_name = "panda.png";
            return File(mas, file_type, file_name);
        }

        // Отправка потока
        public FileResult GetStream()
        {
            string path = Server.MapPath("~/Images/panda.png");
            // Объект Stream
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "image/png";
            string file_name = "panda.png";
            return File(fs, file_type, file_name);
        }

        public string ContextRequest()
        {
            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;

            bool IsAdmin = HttpContext.User.IsInRole("admin"); // определяем, принадлежит ли пользователь к администраторам
            bool IsAuth = HttpContext.User.Identity.IsAuthenticated; // аутентифицирован ли пользователь
            string login = HttpContext.User.Identity.Name; // логин авторизованного пользователя

            return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
                "</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>" +
                "<p>User is admin " + IsAdmin + "</p><p>User is authenticated " + IsAuth + "</p>Login "
                + login + "</p>";
        }

        public void ContextResponse()
        {
            HttpContext.Response.Write("<h1>Hello World</h1><p>I'm written directly to response</p>");
        }

        public RedirectToRouteResult SetCookie(int q)
        {
            HttpContext.Response.Cookies["quantity"].Value = q.ToString();
            return RedirectToAction("GetCookie");
        }

        public string GetCookie()
        {
            return "Quantity from cookies = " + HttpContext.Request.Cookies["quantity"].Value;
        }

        public RedirectToRouteResult SetNameInSession()
        {
            Session["name"] = "Anna";
            return RedirectToAction("GetNameFromSession");
        }

        public string GetNameFromSession()
        {
            var val = Session["name"];
            return "Name from session = " + val.ToString();
        }

        public ActionResult CustomValidation()
        {
            var model = new BookCustom()
            {
                Name = "Преступление и наказание",
                Author = "Ф. Достоевский",
                Year = 1866
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CustomValidation(BookCustom model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult ModelValidation()
        {
            var model = new BookNotAllowed()
            {
                Name = "Преступление и наказание",
                Author = "Ф. Достоевский",
                Year = 1866
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ModelValidation(BookNotAllowed model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult SelfValidation()
        {
            var model = new BookValidatable()
            {
                Year = 1699
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SelfValidation(BookValidatable model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult ValidatorProvider()
        {
            var model = new Book()
            {
                Name = "Преступление и наказание",
                Author = "Ф. Достоевский",
                Year = 1866
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ValidatorProvider(Book model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [IndexException]
        public ActionResult IndexException()
        {
            int[] mas = new int[2];
            mas[6] = 4;
            return View();
        }

        // Чтобы заработало, нужно раскомментить <customErrors mode="On" /> в Web.config
        [HandleError(ExceptionType = typeof(System.IndexOutOfRangeException), View = "ExceptionFound")]
        public ActionResult HandleError()
        {
            int[] mas = new int[2];
            mas[6] = 4;
            return View();
        }

        [CustomAction]
        public ActionResult CustomAction()
        {
            return View();
        }

        [CustomResult]
        public ActionResult CustomResult()
        {
            return View();
        }

        [Cache(Duration = 400)]
        public ActionResult Cache()
        {
            return View();
        }

        [Compress]
        public ActionResult Compress()
        {
            return View();
        }

        [Whitespace]
        public ActionResult Whitespace()
        {
            return View();
        }

        [Log]
        public ActionResult Log()
        {
            return View();
        }

        public ActionResult Argument(int arg)
        {
            return View();
        }

        public ActionResult BindInclude([Bind(Include = "Name, Author")] ClearBook b)
        {
            return View("BindBook", b);
        }

        public ActionResult BindExclude([Bind(Exclude = "Year")] ClearBook b)
        {
            return View("BindBook", b);
        }

        public ActionResult BindModel(BookBind b)
        {
            return View("BindBookModel", b);
        }

        public ActionResult UpdateModel()
        {
            var book = new ClearBook();
            try
            {
                UpdateModel(book);
                return View("BindBook", book);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult TryUpdateModel()
        {
            var book = new ClearBook();
            if (TryUpdateModel(book))
            {
                return View("BindBook", book);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public string BrowserInfo(string browser)
        {
            return browser;
        }

        public ActionResult ModelBinder(BookForBinder b)
        {
            return View(b);
        }

        public ActionResult Modules()
        {
            var modules = HttpContext.ApplicationInstance.Modules;
            string[] modArray = modules.AllKeys;
            return View(modArray);
        }
    }
}
