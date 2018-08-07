using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Remote.Interfaces
{
    public interface IContactService
    {
        IEnumerable<ContactDto> Read();
        void Add(ContactDto contact);
        void Remove(ContactDto contact);
        void Edit(ContactDto contactDto);
    }
}