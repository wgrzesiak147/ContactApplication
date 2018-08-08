using ContactApplication.Application.Views;

namespace ContactApplication.Application.ViewModels
{
    public interface IMainPageViewModel
    {
        IMainPage MainPage { get; set; }

        void LoadContacts();
    }
}