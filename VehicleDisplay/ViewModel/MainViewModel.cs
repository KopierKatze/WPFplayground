using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace VehicleDisplay.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                WindowTitle = "Vehicle Display (Design Mode)";
            }
            else
            {
                WindowTitle = "VehicleDisplay";
            }

            FillWithExampleVehicles();
        }

        public string WindowTitle { get; private set; }

        private ObservableCollection<Vehicle> Vehicles { get; set; }
        public ListCollectionView VehiclesView { get; private set; }


        public Vehicle VehicleModel {
            get => VehiclesView.CurrentItem as Vehicle;
            set
            {
                VehiclesView.MoveCurrentTo(value);
                RaisePropertyChanged();
            }
        }

        public RelayCommand OpenChildCommand { get; }


        private void FillWithExampleVehicles()
        {

            List<Vehicle> exampleVehicles = new List<Vehicle>();
            
            for (int i = 0; i < 5; i++)
            {
                string iStr = i.ToString();
                string name = string.Format("Vehicle {0}", iStr);
                string model = string.Format("model {0}", iStr);
                Vehicle.VehicleType type = GetVehicleTypeFromIndex(i);
                Vehicle exampleVehicle = new Vehicle(name, model, type);
                exampleVehicles.Add(exampleVehicle);
            }

            Vehicles = new ObservableCollection<Vehicle>(exampleVehicles);
            VehiclesView = CollectionViewSource.GetDefaultView(Vehicles) as ListCollectionView;

            VehiclesView.CurrentChanged += (s, e) =>
            {
                RaisePropertyChanged(() => VehicleModel);
            };

            foreach (Vehicle v in Vehicles)
            {
                v.PropertyChanged += VehiclePropertyChanged;
            }

            Vehicles.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (INotifyPropertyChanged added in e.NewItems)
                    {
                        added.PropertyChanged += VehiclePropertyChanged;
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (INotifyPropertyChanged removed in e.OldItems)
                    {
                        removed.PropertyChanged -= VehiclePropertyChanged;
                    }
                }
            };

        }

        protected void VehiclePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(VehicleModel.IsValid))
            {
                return;
            }
            VehiclesView.Refresh();
        }

        private Vehicle.VehicleType GetVehicleTypeFromIndex(int index)
        {
            index = index % 3;
            if (Enum.IsDefined(typeof(Vehicle.VehicleType), index))
                return (Vehicle.VehicleType)index;
            else
                return Vehicle.VehicleType.CAR;
        }

        
    }
}

