using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ContactApplication.Database.Mappers;
using ContactApplication.Database.Model;
using ContactApplication.Database.Repository;
using ContactApplication.Interfaces.Model;

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
        public IEnumerable<ContactDto> Get()
        {
            var contacts =  ContactRepository.GetContacts().Select(x=> ContactDtoMapper.Map(x)).ToList();
            return contacts;
        }

        public void Post([FromBody] ContactDto contact)
        {
            ContactRepository.AddContact(contact);
        }

        public void Put([FromBody] ContactDto contact)
        {
            ContactRepository.UpdateContact(contact);
        }

        public void Delete(ContactDto contact)
        {
            ContactRepository.RemoveContact(contact);
        }
    }
}