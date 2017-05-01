namespace RocketLaunch.Models
{
    using RocketLaunch.DAL;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Helper
    {
        public static Rocket GetRocket(string rocketName)
        {
            RocketLauncherDAL rdal = new RocketLauncherDAL();
            Rocket rocket = (from s in rdal.Rockets
                where s.Name == rocketName
                select s).FirstOrDefault<Rocket>();
            if (rocket != null)
            {
                return rocket;
            }
            return null;
        }

        public static List<Rocket> GetRockets()
        {
            RocketLauncherDAL rdal = new RocketLauncherDAL();
            if (rdal.Rockets != null)
            {
                return rdal.Rockets.ToList<Rocket>();
            }
            return null;
        }

        public static Satellite GetSatellite(string satelliteName)
        {
            RocketLauncherDAL rdal = new RocketLauncherDAL();
            Satellite satellite = (from s in rdal.Satellites
                where s.Name == satelliteName
                select s).FirstOrDefault<Satellite>();
            if (satellite != null)
            {
                return satellite;
            }
            return null;
        }

        public static List<Satellite> GetSatellites()
        {
            RocketLauncherDAL rdal = new RocketLauncherDAL();
            if (rdal.Satellites != null)
            {
                return rdal.Satellites.ToList<Satellite>();
            }
            return null;
        }

        public static Rocket SaveRocket(Rocket e, string category)
        {
            RocketLauncherDAL rdal = new RocketLauncherDAL {
                Rockets = { e }
            };
            foreach (string str in e.Satellites.Split(new char[] { ',' }))
            {
                Satellite entity = new Satellite {
                    Name = str,
                    Category = category
                };
                rdal.Satellites.Add(entity);
            }
            rdal.SaveChanges();
            return e;
        }

        public static Rocket UpdateRocket(Rocket e)
        {
            RocketLauncherDAL rdal = new RocketLauncherDAL();
            Rocket rocket = (from s in rdal.Rockets
                where s.Name == e.Name
                select s).FirstOrDefault<Rocket>();
            rocket.Destination = e.Destination;
            rocket.Satellites = e.Satellites;
            rdal.SaveChanges();
            return e;
        }

        public static Satellite UpdateSatellite(Satellite e)
        {
            RocketLauncherDAL rdal = new RocketLauncherDAL();
            (from s in rdal.Satellites
                where s.Name == e.Name
                select s).FirstOrDefault<Satellite>().Category = e.Category;
            rdal.SaveChanges();
            return e;
        }
    }
}

