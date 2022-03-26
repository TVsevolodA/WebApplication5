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

        [HttpPost]
        public ActionResult Index(float? firstNumber, string action, float? secondNumber)
        {
            if (firstNumber == null)
            {
                if (action == "-")
                {
                    ViewData["Result"] = -secondNumber;
                }
                else
                {
                    ViewData["Result"] = secondNumber;
                }
            }
            else if (secondNumber == null)
            {
                ViewData["Result"] = firstNumber;
            }
            else if (firstNumber == null && secondNumber == null)
            {
                ViewData["Result"] = "";
            }
            else
            {
                switch (action)
                {
                    case ("+"):
                        ViewData["Result"] = firstNumber + secondNumber;
                        break;
                    case ("-"):
                        ViewData["Result"] = firstNumber - secondNumber;
                        break;
                    case ("*"):
                        ViewData["Result"] = firstNumber * secondNumber;
                        break;
                    case ("/"):
                        if (secondNumber == 0)
                        {
                            ViewData["Result"] = "Нельзя делить на 0";
                            break;
                        }
                        ViewData["Result"] = firstNumber / secondNumber;
                        break;
                }
            }
            ViewData["first"] = firstNumber;
            ViewData["second"] = secondNumber;
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