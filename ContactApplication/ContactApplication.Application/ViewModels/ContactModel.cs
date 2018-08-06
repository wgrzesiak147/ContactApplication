using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ContactApplication.Application.ViewModels
{
    public class ContactModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<string> ListOfEmails { get; set; }

        public List<string> ListOfPhoneNumbers { get; set; }

        public string EmailString
        {
            get
            {
                if (ListOfEmails == null) return "";
                return String.Join(",", ListOfEmails);
            }
        }

        public string PhoneString
        {
            get
            {
                if (ListOfPhoneNumbers == null) return "";
                return String.Join(",", ListOfPhoneNumbers);
            }
        }
    }
}