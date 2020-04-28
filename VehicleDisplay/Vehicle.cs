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

        public Vehicle(string vehicleName, string vehicleModel, VehicleType vehicleType)
        {
            Name = vehicleName;
            Id = Guid.NewGuid();
            Model = vehicleModel;
            Type = vehicleType;
            Position = new Point(0, 0);
            Speed = 0f;
        }

        public void SetSpeed(float newSpeed)
        {
            Speed = newSpeed;
        }

        public void SetPosition(Point newPosition)
        {
            Position = newPosition;
        }
    }
}
