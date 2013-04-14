 #if AAT
namespace Excella.Lean.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using System.Configuration;
    using System.Web.Configuration;
    using System.Web.Routing;

    using Excella.Lean.Web.Models.Aat;

    public class AatController : Controller
    {
        //
        // GET: /Aat/
        public ActionResult AatInput()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AatInput(Inputs input)
        {
            //SetSetting(AppSettings.UseSiteMinderSimulator, "true");
            //SetSetting(AppSettings.ConfigIndividualKey, input.IndividualKey);

            var result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                action = "Index",
                controller = "Home"
            }));

            return result;
        }

        // TODO: temporarily comment out this method, since calls to it have been temporarily commented out
        //void SetSetting(string key, string value)
        //{
        //    var configuration = WebConfigurationManager.OpenWebConfiguration("/ExcellaLean/"); // "~\\..\\Excella.Lean.Web");
        //    var section = (AppSettingsSection)configuration.GetSection("appSettings");
        //    section.Settings[key].Value = value;
        //    configuration.Save();
        //}

    }
}
#endif