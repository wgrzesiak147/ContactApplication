using ContactApplication.Application.Mappers;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public class AddContactPageViewModel : ContactPageViewModelBase
    {
        public AddContactPageViewModel(NavigationController navigationController) : base(navigationController)
        {
        }

        public override async void Save()
        {
            await ContactService.AddAsync(ContactModelMapper.Map(Contact));
            NavigationController.CurrentPage = new MainPage(NavigationController);
        }
    }
}