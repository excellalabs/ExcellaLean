namespace InternalUi.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Home Page";

            return View();
        }
    }
}
