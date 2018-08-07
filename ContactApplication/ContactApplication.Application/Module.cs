using ContactApplication.Application.Navigation;
using ContactApplication.Application.ViewModels;
using ContactApplication.Application.ViewModels.ContactPages;
using ContactApplication.Application.Views;
using ContactApplication.Remote.Interfaces;
using ContactApplication.Remote.Services;
using Ninject.Modules;

namespace ContactApplication.Application
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainPage>().To<MainPage>();
            Bind<INavigationController>().To<NavigationController>().InSingletonScope();
            Bind<IAddContactPage>().To<AddContactPage>();
            Bind<IAddContactPageViewModel>().To<AddContactPageViewModel>();
            Bind<IEditContactPageViewModel>().To<EditContactPageViewModel>();
            Bind<IMainWindowViewModel>().To<MainWindowViewModel>();
            Bind<IMainPageViewModel>().To<MainPageViewModel>();
            Bind<IContactService>().To<ContactService>();
            Bind<IHttpClientFactory>().To<HttpJsonClientFactory>();
        }
    }
}