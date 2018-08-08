using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ContactApplication.Database.Model;

namespace ContactApplication.Database.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        public IEnumerable<Contact> GetContacts()
        {
            return _dbContext.Contacts.Include(x => x.Emails).Include(x => x.PhoneNumbers);
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

            foreach (var email in contact.Emails.ToList())
                if (email.State == EntityState.Added)
                {
                    var emailEntity = new Email {Id = email.Id, Address = email.Address};
                    contact.Emails.Add(emailEntity);
                }

            foreach (var phoneNumber in contact.PhoneNumbers.ToList())
                if (phoneNumber.State == EntityState.Added)
                {
                    var phoneNumberEntity = new PhoneNumber {Id = phoneNumber.Id, Number = phoneNumber.Number};
                    contact.PhoneNumbers.Add(phoneNumberEntity);
                }

            _dbContext.SaveChanges();
        }
    }
}