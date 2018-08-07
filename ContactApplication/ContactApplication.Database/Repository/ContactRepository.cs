using System.Collections.Generic;
using System.Data.Entity;
using ContactApplication.Database.Model;

namespace ContactApplication.Database.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        public IEnumerable<Contact> GetContacts()
        {
            return _dbContext.Contacts;
        }

        public void AddContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }

        public void RemoveContact(Contact contact)
        {
            _dbContext.Contacts.Attach(contact);
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            _dbContext.Contacts.Attach(contact);
            _dbContext.Entry(contact).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}