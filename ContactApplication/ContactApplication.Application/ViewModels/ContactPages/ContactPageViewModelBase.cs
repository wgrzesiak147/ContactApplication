using System;
using System.Windows.Input;
using ContactApplication.Application.Navigation;
using ContactApplication.Remote.Interfaces;
using ContactApplication.Remote.Services;
using GalaSoft.MvvmLight.CommandWpf;

namespace ContactApplication.Application.ViewModels.ContactPages
{
    public abstract class ContactPageViewModelBase
    {
        protected IContactService ContactService { get; set; }

        public ContactModel Contact { get; set; }

        protected NavigationController NavigationController { get; set; }

        protected ContactPageViewModelBase(NavigationController navigationController)
        {
            NavigationController = navigationController;
            Contact = new ContactModel {DateOfBirth = DateTime.Today};
            SaveCommand = new RelayCommand(Save);
        }

        public ICommand SaveCommand { get; set; }

        public abstract void Save();
    }
}