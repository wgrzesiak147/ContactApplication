using System.Windows.Controls;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;

namespace ContactApplication.Application.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public MainWindowViewModel(INavigationController navigationController, IMainPage mainPage)
        {
            NavigationController = navigationController;
            navigationController.CurrentPage = (Page) mainPage;
        }

        public INavigationController NavigationController { get; set; }
    }
}