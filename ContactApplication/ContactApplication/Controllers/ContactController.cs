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
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                DateOfBirth = c.DateOfBirth,
                ListOfPhoneNumbers = c.ListOfPhoneNumbers?.ToList(),
                ListOfEmails = c.ListOfEmails?.ToList(),
            });
        }

        // POST api/<controller>
        public void Post([FromBody] Contact contact)
        {
            _contactRepository.AddContact(contact);
        }

        // PUT api/<controller>/5
        public void Put([FromBody] Contact contact)
        {
            _contactRepository.UpdateContact(contact);
        }

        // DELETE api/<controller>/5
        public void Delete(Contact contact)
        {
            _contactRepository.RemoveContact(contact);
        }
    }
}