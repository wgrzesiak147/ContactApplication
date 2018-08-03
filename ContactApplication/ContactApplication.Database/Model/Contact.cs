using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactApplication.Database.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Microsoft.Build.Framework.Required]
        public string FirstName { get; set; }

        [Microsoft.Build.Framework.Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<string> ListOfEmails { get; set; }

        public IEnumerable<string> ListOfPhoneNumbers { get; set; }
    }
}