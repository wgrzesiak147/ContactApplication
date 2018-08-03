using System;
using System.Collections.Generic;
using ContactApplication.Database.Model;

namespace ContactApplication.Database.Repository
{
    public class ContactRepository : IContactRepository
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        public IEnumerable<Contact> GetContacts()
        {
            return _dbContext.Contacts;
        }

        public void AddContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }

        public void RemeveContact(Contact contact)
        {
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }
    }
}