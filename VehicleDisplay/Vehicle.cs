using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace VehicleDisplay
{
    abstract class Vehicle
    {
        #region Vehicle data
        public string Name { get; private set; }

        public Guid Id { get; private set; }

        public string Model { get; private set; }

        public enum VehicleType
        {
            CAR, TRUCK, MOTORCYCLE
        }

        public VehicleType Type { get; private set; }

        public Point Position { get; set; }

        public float Speed { get; set; }

        #endregion
    }
}
