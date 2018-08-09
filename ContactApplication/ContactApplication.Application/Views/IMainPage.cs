using ContactApplication.Application.ViewModels;

namespace ContactApplication.Application.Views
{
    public interface IMainPage
    {
        IMainPageViewModel ViewModel { get; set; }
    }
}