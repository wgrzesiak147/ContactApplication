using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;
using ContactApplication.Interfaces.Model;
using ContactApplication.Remote.Interfaces;
using ContactApplication.Remote.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ContactApplication.Application.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<ContactModel> Contacts { get; set; }

        private NavigationController _navigationController { get; set; }

        private IContactService _contactService { get; set; }

        public MainPageViewModel(Navigation.NavigationController navigationController)
        {
            _contactService = new ContactService();
            _navigationController = navigationController;
            this.AddContactCommand = new RelayCommand(AddContact);
            this.LoadContactsCommand = new RelayCommand(LoadContacts);

            Contacts = new ObservableCollection<ContactModel>();

        }

        private void LoadContacts()
        {
            Contacts.Clear();

            var contacts = _contactService.Read();
            foreach (var contact in contacts)
            {
                Contacts.Add(new ContactModel()
                {
                    DateOfBirth = contact.DateOfBirth,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    ListOfEmails = contact.ListOfEmails,
                    ListOfPhoneNumbers = contact.ListOfPhoneNumbers
                });
            }
        }

        public ContactModel SelectedContact { get; set; }

        public ICommand LoadContactsCommand { get; set; }

        public ICommand AddContactCommand { get; private set; }

        public void AddContact()
        {
            _navigationController.CurrentPage = new AddContactPage(_navigationController);
        }
    }
}