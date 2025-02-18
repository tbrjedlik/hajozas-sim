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
        public double Speed { get; set; }
        public string CurrentStatus { get; set; }
        public (double x, double y) CurrentPosition { get; set; }
        public List<Cargo> ShipCargo { get; set; }

        public Ship(string shipId, string shipType, double capacity, double speed)
        {
            ShipId = shipId;
            ShipType = shipType;
            Capacity = capacity;
            Speed = speed;
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

        public void LoadCargo(Cargo cargo)
        {
            if (cargo == null)
                throw new ArgumentNullException(nameof(cargo), "A rakomány nem lehet null.");

            double totalWeight = 0;
            foreach (var c in ShipCargo)
            {
                totalWeight += c.Weight;
            }

            if (totalWeight + cargo.Weight > Capacity)
                throw new InvalidOperationException("A hajó nem bír el ennyi rakományt.");

            ShipCargo.Add(cargo);
        }

        public void UnloadCargo(Cargo cargo)
        {
            if (cargo == null)
                throw new ArgumentNullException(nameof(cargo), "A rakomány nem lehet null.");

            ShipCargo.Remove(cargo);
        }
    }
}
