using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    public class MilitaryShip : Ship
    {
        public string Armament { get; set; }

        public MilitaryShip(string shipId, double capacity, double speed, string armament)
            : base(shipId, "MilitaryShip", capacity, speed)
        {
            Armament = armament;
        }

        public void DefendAgainstPirates()
        {
            
        }

    }
}
