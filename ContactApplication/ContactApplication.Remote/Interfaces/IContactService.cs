using System.Collections.Generic;
using System.Threading.Tasks;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Remote.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> ReadAsync();
        void AddAsync(ContactDto contact);
        void RemoveAsync(ContactDto contact);
        void EditAsync(ContactDto contactDto);
    }
}