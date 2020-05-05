
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleDisplay.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {

            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<VehicleDetailViewModel>();
        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public VehicleDetailViewModel VehicleDetailViewModel => ServiceLocator.Current.GetInstance<VehicleDetailViewModel>();

        public static void Cleanup()
        {

        }
    }
}
