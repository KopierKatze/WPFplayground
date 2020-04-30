using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;


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
        }


        public string WindowTitle { get; private set; }
    }
}
