using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public class EditContactPageViewModel : ContactPageViewModelBase
    {
        public EditContactPageViewModel(NavigationController navigationController, ContactModel model) : base(navigationController)
        {
            Contact = model;
        }

        public override void Save()
        {
            ContactService.Edit(new ContactDto()
            {
                Id = Contact.Id,
                FirstName = Contact.FirstName,
                LastName = Contact.LastName,
                DateOfBirth = Contact.DateOfBirth,
                ListOfEmails = Contact.ListOfEmails,
                ListOfPhoneNumbers = Contact.ListOfPhoneNumbers
            });
            NavigationController.CurrentPage = new MainPage(NavigationController);
        }
    }
}
