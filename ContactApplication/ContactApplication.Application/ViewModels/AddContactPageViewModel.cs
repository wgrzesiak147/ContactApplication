using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApplication.Application.Navigation;
using ContactApplication.Application.Views;
using ContactApplication.Interfaces.Model;
using ContactApplication.Remote.Interfaces;
using ContactApplication.Remote.Services;
using GalaSoft.MvvmLight.CommandWpf;

namespace ContactApplication.Application.ViewModels
{
    class AddContactPageViewModel
    {

        private IContactService _contactService = new ContactService();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Today;

        private NavigationController _navigationController { get; set; }

        public AddContactPageViewModel(NavigationController navigationController)
        {
            _navigationController = navigationController;
            SaveCommand = new RelayCommand(Save);
        }

        public ICommand SaveCommand { get; set; }

        public void Save()
        {
            _contactService.Add(new ContactDto()
            {
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = BirthDate
            });
            _navigationController.CurrentPage = new MainPage(_navigationController);
        }
    }
}