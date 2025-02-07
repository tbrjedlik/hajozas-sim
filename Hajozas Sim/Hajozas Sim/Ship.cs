using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    public class Ship
    {
        public string ShipId { get; set; }
        public string ShipType { get; set; }
        public double Capacity { get; set; }
        public string CurrentStatus { get; set; }
        public (double x, double y) CurrentPosition { get; set; }
        public List<Cargo> ShipCargo { get; set; }

        public Ship(string shipId, string shipType, double capacity)
        {
            ShipId = shipId;
            ShipType = shipType;
            Capacity = capacity;
            CurrentStatus = "Docked";
            CurrentPosition = (0, 0);
            ShipCargo = new List<Cargo>();
        }

        public void Depart()
        {
            CurrentStatus = "Sailing";
        }

        public void Arrive()
        {
            CurrentStatus = "Docked";
        }
    }
}
