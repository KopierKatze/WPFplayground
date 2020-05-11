using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;

namespace VehicleDisplay.ViewModel
{
    public class VehicleDetailViewModel : ViewModelBase
    {
        public VehicleDetailViewModel()
        {
            DetailWindowTitle = "Add new vehicle";
        }
        
        public string DetailWindowTitle { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vehicle name may not be empty.")]
        [MaxLength(30, ErrorMessage = "Vehicle name may not exceed 30 characters.")]
        public string Name { get; private set; }

        public Guid Id { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vehicle model may not be empty.")]
        [MaxLength(30, ErrorMessage = "Vehicle type may not exceed 30 characters.")]
        public string Model { get; private set; }

        [EnumDataType(typeof(Vehicle.VehicleType), ErrorMessage = "Vehicle type needs to be one of the supported vehicle types.",
            ErrorMessageResourceName = "VehicleType", ErrorMessageResourceType = typeof(Vehicle.VehicleType))]
        public Vehicle.VehicleType Type { get; private set; }

        public Point Position { get; set; }

        public float Speed { get; set; }
    }
}
