using System.Collections.Generic;
using ContactApplication.DB.Model;

namespace ContactApplication.DB.Repository
{
    public class ContactRepository : IContactRepository
    {
        public IEnumerable<Contact> GetContacts()
        {
            throw new System.NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveContact(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateContact(Contact contact)
        {
            throw new System.NotImplementedException();
        }
    }
}