using MetanitMvc5.Util;
using System;
using System.Collections.Generic;
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
    }
}
