using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactApplication.Database.Model;
using ContactApplication.Database.Repository;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Controllers
{
    public class ContactController : ApiController
    {
        private IContactRepository _contactRepository { get; set; }

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        // GET api/<controller>
        public IEnumerable<ContactDto> Get()
        {
            return _contactRepository.GetContacts().Select(c => new ContactDto()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                ListOfPhoneNumbers = c.ListOfPhoneNumbers?.ToList(),
                ListOfEmails = c.ListOfEmails?.ToList(),
            });
        }

        // POST api/<controller>
        public void Post([FromBody]ContactDto contact)
        {
            _contactRepository.AddContact(new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                DateOfBirth = contact.DateOfBirth,
                ListOfPhoneNumbers = contact.ListOfPhoneNumbers?.ToList(),
                ListOfEmails = contact.ListOfEmails?.ToList(),
            });
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(Contact contact)
        {
            _contactRepository.RemoveContact(contact);
        }
    }
}