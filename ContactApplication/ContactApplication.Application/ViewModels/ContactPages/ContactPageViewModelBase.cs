using System;
using System.Windows.Controls;
using System.Windows.Input;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Services;
using ContactApplication.Application.Views;
using ContactApplication.Remote.Interfaces;
using GalaSoft.MvvmLight.CommandWpf;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public abstract class ContactPageViewModelBase
    {
        protected ContactPageViewModelBase(IMainPage mainPage, INavigationController navigationController,
            IContactService contactService, INotificationService notificationService)
        {
            MainPage = mainPage;
            ContactService = contactService;
            NotificationService = notificationService;
            NavigationController = navigationController;
            Contact = new ContactModel {DateOfBirth = DateTime.Today};
            SaveCommand = new RelayCommand(SaveBase);
            ExitCommand = new RelayCommand(Exit);
        }

        protected IContactService ContactService { get; set; }

        protected INotificationService NotificationService { get; set; }

        public IMainPage MainPage { get; set; }

        public ContactModel Contact { get; set; }

        protected INavigationController NavigationController { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        private void Exit()
        {
            NavigationController.CurrentPage = (Page) MainPage;
        }


        private void SaveBase()
        {
            Validate();
            Save();
        }

        protected virtual void Validate()
        {
            if (string.IsNullOrEmpty(Contact.FirstName) || string.IsNullOrEmpty(Contact.FirstName))
            {
                NotificationService.ShowMessage("First Name and Last Name are required");
            }
        }

        public abstract void Save();
    }
}