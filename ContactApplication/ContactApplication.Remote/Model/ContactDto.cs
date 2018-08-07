using System;
using System.Collections.Generic;

namespace ContactApplication.Remote.Model
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<string> ListOfEmails { get; set; }

        public List<string> ListOfPhoneNumbers { get; set; }
    }
}