namespace RocketLaunch.Controllers
{
    using RocketLaunch.Models;
    using RocketLaunch.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class SatellitesController : Controller
    {
        public ActionResult SatellitesList()
        {
            List<Satellite> satellites = Helper.GetSatellites();
            SatellitesViewModel model = new SatellitesViewModel {
                Satellites = satellites
            };
            return base.View("SatellitesView", model);
        }

        public ActionResult Update(string satelliteName)
        {
            Satellite model = Helper.GetSatellite(satelliteName);
            return base.View("ModifySatellite", model);
        }

        public ActionResult UpdateSatellite(Satellite e)
        {
            Helper.UpdateSatellite(e);
            return base.View("SatellitesView");
        }
    }
}

