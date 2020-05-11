using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;

namespace VehicleDisplay
{
    // Vehicle Model class
    //Used https://www.codingfreaks.de/wpf-mvvm-01/ as a guide for the implementation. 
    public class Vehicle : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Vehicle data
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vehicle name may not be empty.")]
        [MaxLength(30, ErrorMessage = "Vehicle name may not exceed 30 characters.")]
        public string Name { get; private set; }

        public Guid Id { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vehicle model may not be empty.")]
        [MaxLength(30, ErrorMessage = "Vehicle type may not exceed 30 characters.")]
        public string Model { get; private set; }

        public enum VehicleType
        {
            CAR = 0, TRUCK = 1, MOTORCYCLE = 2
        }

        [EnumDataType(typeof(VehicleType), ErrorMessage ="Vehicle type needs to be one of the supported vehicle types.", 
            ErrorMessageResourceName = "VehicleType", ErrorMessageResourceType = typeof(VehicleType))]
        public VehicleType Type { get; private set; }

        public Point Position { get; set; }

        public float Speed { get; set; }
        #endregion

        private Dictionary<string, string> ErrorInfo { get; } = new Dictionary<string, string>();

        private static List<PropertyInfo> propertyInfos;
        private List<PropertyInfo> PropertyInfos
        {
            get
            {
                if (propertyInfos == null)
                {
                    propertyInfos = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(
                        property => property.IsDefined(typeof(RequiredAttribute), true) || 
                        property.IsDefined(typeof(MaxLengthAttribute), true)) as List<PropertyInfo>;
                }
                return propertyInfos;
            }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                CollectErrorInfo();
                return ErrorInfo.ContainsKey(columnName) ? ErrorInfo[columnName] : string.Empty;
            }
        }

        public bool IsValid { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public Vehicle()
        {
            Name = "";
            Id = Guid.NewGuid();
            Model = "";
            Type = VehicleType.CAR;
            Position = new Point(0, 0);
            Speed = 0f;
        }

        public Vehicle(string vehicleName, string vehicleModel, VehicleType vehicleType)
        {
            Name = vehicleName;
            Id = Guid.NewGuid();
            Model = vehicleModel;
            Type = vehicleType;
            Position = new Point(0, 0);
            Speed = 0f;
        }


        private void CollectErrorInfo()
        {
            ErrorInfo.Clear();
            PropertyInfos.ForEach(
                property =>
                {
                    object currentValue = property.GetValue(this);
                    RequiredAttribute requiredAttribute = property.GetCustomAttribute<RequiredAttribute>(true);
                    MaxLengthAttribute maxLenAttribute = property.GetCustomAttribute<MaxLengthAttribute>(true);

                    if (requiredAttribute != null)
                    {
                        if (string.IsNullOrEmpty(currentValue?.ToString() ?? string.Empty))
                        {
                            ErrorInfo.Add(property.Name, requiredAttribute.ErrorMessage);
                        }
                    }

                    if (maxLenAttribute != null)
                    {
                        if (string.IsNullOrEmpty(currentValue?.ToString() ?? string.Empty))
                        {
                            ErrorInfo.Add(property.Name, maxLenAttribute.ErrorMessage);
                        }
                    }

                    IsValid = ErrorInfo.Count == 0;
                });

        }
    }
}
