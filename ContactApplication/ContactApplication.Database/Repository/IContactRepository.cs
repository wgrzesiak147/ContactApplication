using System.Collections.Generic;
using ContactApplication.Database.Model;

namespace ContactApplication.Database.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();

        Contact GetContactById(int id);

        void AddContact(Contact contact);

        void RemoveContact(Contact contact);
        void UpdateContact(Contact contact);
    }
}