namespace RocketLaunch.Controllers
{
    using RocketLaunch.Models;
    using RocketLaunch.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class RocketsController : Controller
    {
        public ActionResult AddNew() => 
            base.View("CreateRocket");

        public ActionResult Index() => 
            base.View();

        public ActionResult RocketsList()
        {
            List<Rocket> rockets = Helper.GetRockets();
            RocketsViewModel model = new RocketsViewModel {
                Rockets = rockets
            };
            return base.View("RocketsView", model);
        }

        public ActionResult SaveRocket(Rocket e, string BtnSubmit, string category)
        {
            Helper.SaveRocket(e, category);
            return base.RedirectToAction("RocketsList");
        }

        public ActionResult Update(string rocketName)
        {
            Rocket model = Helper.GetRocket(rocketName);
            return base.View("ModifyRocket", model);
        }

        public ActionResult UpdateRocket(Rocket e, string BtnSubmit)
        {
            Helper.UpdateRocket(e);
            return base.RedirectToAction("RocketsList");
        }
    }
}

