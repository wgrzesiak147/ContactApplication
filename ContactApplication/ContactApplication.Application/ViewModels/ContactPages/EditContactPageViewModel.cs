using System.Windows.Controls;
using ContactApplication.Application.Mappers;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;
using ContactApplication.Remote.Interfaces;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public class EditContactPageViewModel : ContactPageViewModelBase, IEditContactPageViewModel
    {
        public EditContactPageViewModel(IMainPage mainPage, INavigationController navigationController,
            IContactService contactService,
            ContactModel model) : base(
            mainPage, navigationController, contactService)
        {
            Contact = model;
        }

        public override async void Save()
        {
            await ContactService.EditAsync(ContactModelMapper.Map(Contact));
            NavigationController.CurrentPage = (Page) MainPage;
            MainPage.ViewModel.LoadContacts();
        }
    }
}