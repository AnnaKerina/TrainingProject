using System.Web.Mvc;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult SecondPage()
        {
            return View();
        }

        public ActionResult ThirdPage()
        {
            return View();
        }

    }
}
