using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    public class CargoShip : Ship
    {
        public List<Cargo> ShipCargo { get; set; }

        public CargoShip(string shipId, double capacity, double speed)
            : base(shipId, "CargoShip", capacity, speed)
        {
            ShipCargo = new List<Cargo>();
        }

        public void LoadCargo(Cargo cargo)
        {
            double totalWeight = ShipCargo.Sum(c => c.Weight);
            if (totalWeight + cargo.Weight > Capacity)
                throw new InvalidOperationException("A rakomány túllépi a hajó kapacitását.");

            ShipCargo.Add(cargo);
        }

        public void UnloadCargo(Cargo cargo)
        {
            ShipCargo.Remove(cargo);
        }

    }
}
