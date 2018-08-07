using System;
using System.Collections.Generic;

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