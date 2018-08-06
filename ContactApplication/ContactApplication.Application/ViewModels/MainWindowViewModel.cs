using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using ContactApplication.Application.Annotations;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ContactApplication.Application.ViewModels
{
    public class MainWindowViewModel
    {
        public NavigationController NavigationController { get; set; }

        public MainWindowViewModel()
        {
            NavigationController = new NavigationController();
            NavigationController.CurrentPage = new MainPage(NavigationController);
        }

    }
}