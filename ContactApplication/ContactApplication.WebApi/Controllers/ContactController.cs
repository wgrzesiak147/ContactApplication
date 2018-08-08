using System.Collections.Generic;
using System.Web.Http;
using ContactApplication.Database.Model;
using ContactApplication.Database.Repository;

namespace ContactApplication.Controllers
{
    public class ContactController : ApiController
    {
        public ContactController(IContactRepository contactRepository)
        {
            ContactRepository = contactRepository;
        }

        private IContactRepository ContactRepository { get; }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return ContactRepository.GetContacts();
        }

        public void Post([FromBody] Contact contact)
        {
            ContactRepository.AddContact(contact);
        }

        public void Put([FromBody] Contact contact)
        {
            ContactRepository.UpdateContact(contact);
        }

        public void Delete(Contact contact)
        {
            ContactRepository.RemoveContact(contact);
        }
    }
}