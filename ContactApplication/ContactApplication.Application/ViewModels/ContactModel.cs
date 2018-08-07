using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace ContactApplication.Application.ViewModels
{
    public class ContactModel
    {

        public ICommand AddEmailCommand { get; set; }
        public ICommand AddPhoneCommand { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public ContactModel()
        {
            AddEmailCommand = new RelayCommand(AddEmail);
            AddPhoneCommand = new RelayCommand(AddPhone);
            ListOfPhoneNumbers = new ObservableCollection<string>();
            ListOfEmails = new ObservableCollection<string>();
        }

        private void AddPhone()
        {
            if(string.IsNullOrEmpty(Phone)) return;
            ListOfEmails.Add(Phone);
        }

        private void AddEmail()
        {
            if(string.IsNullOrEmpty(Email)) return;
            ListOfEmails.Add(Email);
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ObservableCollection<string> ListOfEmails { get; set; }

        public ObservableCollection<string> ListOfPhoneNumbers { get; set; }

        public string EmailString
        {
            get
            {
                if (ListOfEmails == null) return "";
                return string.Join(",", ListOfEmails);
            }
        }

        public string PhoneString
        {
            get
            {
                if (ListOfPhoneNumbers == null) return "";
                return string.Join(",", ListOfPhoneNumbers);
            }
        }
    }
}