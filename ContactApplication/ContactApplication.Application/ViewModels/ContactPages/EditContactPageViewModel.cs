using ContactApplication.Application.Mappers;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public class EditContactPageViewModel : ContactPageViewModelBase
    {
        public EditContactPageViewModel(NavigationController navigationController, ContactModel model) : base(
            navigationController)
        {
            Contact = model;
        }

        public override async void Save()
        {
            await ContactService.EditAsync(ContactModelMapper.Map(Contact));
            NavigationController.CurrentPage = new MainPage(NavigationController);
        }
    }
}