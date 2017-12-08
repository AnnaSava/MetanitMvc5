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
    }
}
