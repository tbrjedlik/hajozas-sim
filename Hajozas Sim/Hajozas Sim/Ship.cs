using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    public abstract class Ship
    {
        public string ShipId { get; set; }
        public string ShipType { get; set; }
        public double Capacity { get; set; }
        public double Speed { get; set; }
        public string CurrentStatus { get; set; }
        public (double x, double y) CurrentPosition { get; set; }

        public Ship(string shipId, string shipType, double capacity, double speed)
        {
            ShipId = shipId;
            ShipType = shipType;
            Capacity = capacity;
            Speed = speed;
            CurrentStatus = "Docked";
            CurrentPosition = (0, 0);
        }
        public void Dock(Harbor harbor)
        {
            if (harbor == null)
                throw new ArgumentNullException(nameof(harbor), "A kikötő nem lehet null.");

            harbor.DockShip(this);
            CurrentStatus = "Docked";
        }

        public void Undock(Harbor harbor)
        {
            if (harbor == null)
                throw new ArgumentNullException(nameof(harbor), "A kikötő nem lehet null.");

            harbor.UndockShip(this);
            CurrentStatus = "Sailing";
        }

        public async Task MoveRouteAsync(Route route)
        {
            if (!(route.HarborA.DockedShips.Contains(this) || route.HarborB.DockedShips.Contains(this)))
            {
                throw new InvalidOperationException("A hajó nem dokkolt a kezdő- vagy a végpont kikötőjében.");
            }

            if (route.HarborA.DockedShips.Contains(this))
            {
                this.Undock(route.HarborA);

                int delayTime = (int)((route.Distance) / (Speed) * 1000);
                await Task.Delay(delayTime);

                this.Dock(route.HarborB);
            }
            else
            {
                this.Undock(route.HarborB);

                int delayTime = (int)((route.Distance) / (Speed) * 1000);
                await Task.Delay(delayTime);

                this.Dock(route.HarborA);
            }
        }


    }
}
