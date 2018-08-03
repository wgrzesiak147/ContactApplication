using System.Collections.Generic;
using ContactApplication.DB.Model;

namespace ContactApplication.DB.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();

        Contact GetById(int id);

        bool RemoveContact(Contact contact);

        bool UpdateContact(Contact contact);
    }
}