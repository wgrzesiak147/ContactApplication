using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.ViewModels.ContactPages;
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

        public MainPageViewModel(NavigationController navigationController)
        {
            _contactService = new ContactService();
            _navigationController = navigationController;
            AddContactCommand = new RelayCommand(AddContact);
            RemoveContactCommand = new RelayCommand(RemoveContact);
            LoadContactsCommand = new RelayCommand(LoadContacts);
            EditContactCommand = new RelayCommand(EditContact);

            Contacts = new ObservableCollection<ContactModel>();
        }

        private void EditContact()
        {
            _navigationController.CurrentPage = new AddContactPage(new EditContactPageViewModel(_navigationController, SelectedContact));
        }

        public ICommand RemoveContactCommand { get; set; }

        private void RemoveContact()
        {
            if (SelectedContact == null)
            {
                MessageBox.Show("Select Contact to remove");
                return;
            }
            _contactService.Remove(new ContactDto()
            {
                Id = SelectedContact.Id,
                DateOfBirth = SelectedContact.DateOfBirth,
                FirstName = SelectedContact.FirstName,
                LastName = SelectedContact.LastName,
                ListOfEmails = SelectedContact.ListOfEmails,
                ListOfPhoneNumbers = SelectedContact.ListOfPhoneNumbers
            });

            LoadContacts();
        }

        private void LoadContacts()
        {
            Contacts.Clear();

            var contacts = _contactService.Read();
            foreach (var contact in contacts)
            {
                Contacts.Add(new ContactModel()
                {
                    Id = contact.Id,
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

        public ICommand AddContactCommand { get; set; }

        public ICommand EditContactCommand { get; set; }

        public void AddContact()
        {
            _navigationController.CurrentPage = new AddContactPage(new AddContactPageViewModel(_navigationController));
        }
    }
}