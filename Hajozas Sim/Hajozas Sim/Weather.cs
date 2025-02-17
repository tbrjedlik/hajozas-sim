using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hajozas_Sim
{
    public class Weather
    {
        public string Condition { get; set; }
        public double SpeedEffect { get; set; }

        public Weather(string condition, double speedEffect)
        {
            Condition = condition;
            SpeedEffect = speedEffect;
        }
    }
}