﻿using System;
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

        public void Depart()
        {
            CurrentStatus = "Sailing";
        }
        public void Arrive()
        {
            CurrentStatus = "Docked";
        }

        //public abstract void DisplayInfo();
    }
}
