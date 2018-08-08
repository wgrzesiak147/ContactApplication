using System.Collections.Generic;
using System.Threading.Tasks;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Remote.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> ReadAsync();
        Task AddAsync(ContactDto contact);
        Task RemoveAsync(ContactDto contact);
        Task EditAsync(ContactDto contactDto);
    }
}