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

        public void LoadCargo(Cargo cargo, Harbor harbor)
        {
            if (cargo == null)
                throw new ArgumentNullException(nameof(cargo), "A rakomány nem lehet null.");

            if (harbor == null)
                throw new ArgumentNullException(nameof(harbor), "A kikötő nem lehet null.");

            if (!harbor.CargoList.Contains(cargo))
                throw new InvalidOperationException("A rakomány nincs a kikötőben.");

            double totalCargoWeight = 0;
            foreach (var cargoItem in ShipCargo)
            {
                totalCargoWeight += cargoItem.Weight;
            }

            if (totalCargoWeight + cargo.Weight > Capacity)
            {
                throw new InvalidOperationException("A rakomány túllépi a hajó kapacitását.");
            }

            harbor.CargoList.Remove(cargo);
            ShipCargo.Add(cargo);
        }

        public void UnloadCargo(Cargo cargo, Harbor harbor)
        {
            if (cargo == null)
                throw new ArgumentNullException(nameof(cargo), "A rakomány nem lehet null.");

            if (harbor == null)
                throw new ArgumentNullException(nameof(harbor), "A kikötő nem lehet null.");

            if (!ShipCargo.Contains(cargo))
            {
                throw new InvalidOperationException("A rakomány nem található a hajó rakománya között.");
            }

            double totalHarborCargoWeight = 0;
            foreach (var cargoItem in harbor.CargoList)
            {
                totalHarborCargoWeight += cargoItem.Weight;
            }

            if (cargo.Weight + totalHarborCargoWeight > harbor.CargoCapacity)
            {
                throw new InvalidOperationException("A rakomány túllépi a kikötő kapacitását.");
            }

            ShipCargo.Remove(cargo);
            harbor.CargoList.Add(cargo);
        }

    }
}
