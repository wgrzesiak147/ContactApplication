using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ContactApplication.Database.Mappers;
using ContactApplication.Database.Model;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Database.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        public IEnumerable<Contact> GetContacts()
        {
            return _dbContext.Contacts.Include(x => x.Emails).Include(x => x.PhoneNumbers);
        }

        public void AddContact(ContactDto contact)
        {
            _dbContext.Contacts.Add(ContactDtoMapper.Map(contact));
            _dbContext.SaveChanges();
        }

        public void RemoveContact(ContactDto contact)
        {
            var cont = ContactDtoMapper.Map(contact);

            _dbContext.Contacts.Attach(cont);
            _dbContext.Contacts.Remove(cont);
            _dbContext.SaveChanges();
        }

        public void UpdateContact(ContactDto contact)
        {
            var cont = ContactDtoMapper.Map(contact);
            _dbContext.Contacts.Attach(cont);
            _dbContext.Entry(cont).State = EntityState.Modified;

            foreach (var email in contact.Emails)
            {
                if (email.State == EntityState.Added)
                {
                    var emailEntity = new Email {Id = email.Id, Address = email.Address};
                    cont.Emails.Add(emailEntity);
                }
            }

            foreach (var phoneNumber in contact.PhoneNumbers)
            {
                if (phoneNumber.State == EntityState.Added)
                {
                    var phoneNumberEntity = new PhoneNumber() {Id = phoneNumber.Id, Number = phoneNumber.Number};
                    cont.PhoneNumbers.Add(phoneNumberEntity);
                }
            }

            _dbContext.SaveChanges();
        }
    }
}