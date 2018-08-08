using System.Collections.Generic;
using ContactApplication.Database.Model;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Database.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();

        void AddContact(ContactDto contact);

        void RemoveContact(ContactDto contact);
        void UpdateContact(ContactDto contact);
    }
}