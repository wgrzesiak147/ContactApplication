using System;
using System.Windows.Controls;
using System.Windows.Input;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Services;
using ContactApplication.Application.Views;
using ContactApplication.Remote.Interfaces;
using ContactApplication.Remote.Services;
using GalaSoft.MvvmLight.CommandWpf;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public abstract class ContactPageViewModelBase
    {
        protected IContactService ContactService { get; set; }
        protected INotificationService NotificationService { get; set; }

        public IMainPage MainPage { get; set; }

        public ContactModel Contact { get; set; }

        protected INavigationController NavigationController { get; set; }

        protected ContactPageViewModelBase(IMainPage mainPage, INavigationController navigationController, IContactService contactService, INotificationService notificationService)
        {
            MainPage = mainPage;
            ContactService = contactService;
            NotificationService = notificationService;
            NavigationController = navigationController;
            Contact = new ContactModel {DateOfBirth = DateTime.Today};
            SaveCommand = new RelayCommand(Save);
            ExitCommand = new RelayCommand(Exit);
        }

        private void Exit()
        {
            NavigationController.CurrentPage = (Page)MainPage;
        }

        public ICommand SaveCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public abstract void Save();
    }
}