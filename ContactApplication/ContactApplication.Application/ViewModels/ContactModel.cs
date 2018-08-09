using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace ContactApplication.Application.ViewModels
{
    public class ContactModel
    {
        public ContactModel()
        {
            AddEmailCommand = new RelayCommand(AddEmail);
            AddPhoneNumberCommand = new RelayCommand(AddPhoneNumber);
            ListOfPhoneNumbers = new ObservableCollection<PhoneNumberModel>();
            ListOfEmails = new ObservableCollection<EmailModel>();
        }

        public ICommand AddEmailCommand { get; set; }

        public ICommand AddPhoneNumberCommand { get; set; }

        public string NewEmail { get; set; }

        public string NewPhoneNumber { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ObservableCollection<EmailModel> ListOfEmails { get; set; }

        public ObservableCollection<PhoneNumberModel> ListOfPhoneNumbers { get; set; }

        public string EmailString
        {
            get
            {
                if (ListOfEmails == null) return "";
                return string.Join(",", ListOfEmails.Select(x => x.Address));
            }
        }

        public string PhoneString
        {
            get
            {
                if (ListOfPhoneNumbers == null) return "";
                return string.Join(",", ListOfPhoneNumbers.Select(x => x.Number));
            }
        }

        private void AddPhoneNumber()
        {
            if (string.IsNullOrEmpty(NewPhoneNumber)) return;
            ListOfPhoneNumbers.Add(new PhoneNumberModel {Number = NewPhoneNumber, State = EntityState.Added});
            NewPhoneNumber = "";
        }

        private void AddEmail()
        {
            if (string.IsNullOrEmpty(NewEmail)) return;
            ListOfEmails.Add(new EmailModel {Address = NewEmail, State = EntityState.Added});
            NewEmail = "";
        }
    }
}