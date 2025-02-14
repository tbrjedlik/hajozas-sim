using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    public class Route
    {
        public Harbor StartHarbor { get; set; }
        public Harbor EndHarbor { get; set; }
        public double Distance { get; set; }
        //public double WeatherImpact { get; private set; } = 1.0;

        public Route(Harbor startHarbor, Harbor endHarbor, double distance)
        {
            if (startHarbor == null || endHarbor == null)
                throw new ArgumentNullException("A kikötők nem lehetnek null értékűek.");
            if (distance <= 0)
                throw new ArgumentException("A távolságnak pozitívnak kell lennie.");

            StartHarbor = startHarbor;
            EndHarbor = endHarbor;
            Distance = distance;
        }

        //public double CalculateTravelTime(Ship ship, Weather weather)
        //{
        //    if (ship == null || weather == null)
        //        throw new ArgumentNullException("A hajó és az időjárás nem lehet null értékű.");

        //    double effectiveSpeed = ship.Speed * weather.SpeedEffect;

        //    if (effectiveSpeed <= 0)
        //        throw new InvalidOperationException("A hajó sebessége nem lehet nulla vagy negatív az időjárás miatt.");

        //    return Distance / effectiveSpeed;
        //}
    }
}
