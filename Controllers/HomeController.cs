using System;
using System.Data;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        private static DataTable Table { get; } = new DataTable();
        public static double Calc(string Expression) => Convert.ToDouble(Table.Compute(Expression, string.Empty));
        [HttpPost]
        public ActionResult Index(string str)
        {
            Boolean flag = false;
            String result = "";
            
            try
            {
                result = Calc(str).ToString();
            }
            catch
            {
                flag = true;
            }
            
            if (flag || result == "∞" || result == "-∞" || result == "не число")
                result = "Ошибка вычислений";
            ViewData["Result"] = result;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}