namespace Excella.Lean.Web.Controllers
{
    using System.Web.Mvc;
    using Breeze.WebApi;

    using Elmah;

    using Excella.Lean.Web.Core;

    [JsonFormatter, ODataActionFilter]
    public class HomeController : Controller
    {   
        public HomeController()
        {
        }

        [HttpPost]
        public void LogJavaScriptError(string message)
        {
            ErrorSignal.FromCurrentContext().Raise(new JavaScriptErrorException(message));
        }

        public ActionResult Index()
        {
            // Please use the TestApp project for testing code.
            return this.View();
        }
    }
}
