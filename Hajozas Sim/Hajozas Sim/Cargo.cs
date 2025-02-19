using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    public class Cargo
    {
        public string CargoId { get; set; }
        public string CargoType { get; set; }
        public double Weight { get; set; }
        public Harbor Destination { get; set; }

        public Cargo(string cargoId, string cargoType, double weight, Harbor destination)
        {
            CargoId = cargoId;
            CargoType = cargoType;
            Weight = weight;
            Destination = destination;
        }
    }
}
