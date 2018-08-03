using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace ContactApplication.DB.Model
{
    public class Contact
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public IEnumerable<string> ListOfEmails { get; set; }

        public IEnumerable<string> ListOfPhoneNumbers { get; set; }

    }
}