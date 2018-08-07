using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public class AddContactPageViewModel : ContactPageViewModelBase
    {
        public override void Save()
        {
            ContactService.Add(new ContactDto()
            {
                FirstName = Contact.FirstName,
                LastName = Contact.LastName,
                DateOfBirth = Contact.DateOfBirth,
                ListOfEmails = Contact.ListOfEmails,
                ListOfPhoneNumbers = Contact.ListOfPhoneNumbers
            });
            NavigationController.CurrentPage = new MainPage(NavigationController);
        }

        public AddContactPageViewModel(NavigationController navigationController) : base(navigationController)
        {
        }
    }
}