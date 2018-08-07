using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;

namespace ContactApplication.Application.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            NavigationController = new NavigationController();
            NavigationController.CurrentPage = new MainPage(NavigationController);
        }

        public NavigationController NavigationController { get; set; }
    }
}