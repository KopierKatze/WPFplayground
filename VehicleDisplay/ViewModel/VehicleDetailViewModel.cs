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
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vehicle name may not be empty.")]
        [MaxLength(30, ErrorMessage = "Vehicle name may not exceed 30 characters.")]
        public string Name { get; set; }

        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vehicle model may not be empty.")]
        [MaxLength(30, ErrorMessage = "Vehicle type may not exceed 30 characters.")]
        public string Model { get; set; }

        [EnumDataType(typeof(Vehicle.VehicleType), ErrorMessage = "Vehicle type needs to be one of the supported vehicle types.",
            ErrorMessageResourceName = "VehicleType", ErrorMessageResourceType = typeof(Vehicle.VehicleType))]
        public Vehicle.VehicleType Type { get; set; }

        public Point Position { get; set; }

        public float Speed { get; set; }
    }
}
