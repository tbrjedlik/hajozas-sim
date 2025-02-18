using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    public class Route
    {
        public Harbor HarborA { get; private set; }
        public Harbor HarborB { get; private set; }
        public List<(double x, double y)> Waypoints { get; private set; } = new List<(double x, double y)>();
        public double Distance { get; private set; }

        public Route(Harbor harborA, Harbor harborB, List<(double x, double y)> waypoints = null)
        {
            if (harborA == null || harborB == null)
                throw new ArgumentNullException("A kikötők nem lehetnek null értékűek.");
            if (harborA == harborB)
                throw new ArgumentException("A kezdő- és célkikötő nem lehet ugyanaz.");

            HarborA = harborA;
            HarborB = harborB;

            if (waypoints == null)
            {
                Waypoints = new List<(double x, double y)>();
            }
            else
            {
                Waypoints = waypoints;
            }

            Distance = 0;

            var routePoints = new List<(double x, double y)>();

            routePoints.Add(HarborA.Position);

            foreach (var waypoint in Waypoints)
            {
                routePoints.Add(waypoint);
            }

            routePoints.Add(HarborB.Position);

            for (int i = 0; i < routePoints.Count - 1; i++)
            {
                var currentPoint = routePoints[i];
                var nextPoint = routePoints[i + 1];

                double deltaX = nextPoint.x - currentPoint.x;
                double deltaY = nextPoint.y - currentPoint.y;

                double distanceOfPoints = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

                Distance += distanceOfPoints;
            }
        }


    }

}
