using System.Collections.Generic;
using ContactApplication.Database.Model;

namespace ContactApplication.Database.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();

        void AddContact(Contact contact);

        void RemoveContact(Contact contact);
    }
}