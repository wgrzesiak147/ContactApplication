using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ContactApplication.Interfaces.Model
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