using System.Collections.ObjectModel;
using System.Linq;
using ContactApplication.Application.ViewModels;
using ContactApplication.Remote.Model;

namespace ContactApplication.Application.Mappers
{
    public class ContactModelMapper
    {
        public static ContactModel Map(ContactDto dto)
        {
            return new ContactModel()
            {
                Id = dto.Id,
                DateOfBirth = dto.DateOfBirth,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ListOfEmails = dto.ListOfEmails !=null ? new ObservableCollection<string>(dto.ListOfEmails): new ObservableCollection<string>(),
                ListOfPhoneNumbers = dto.ListOfPhoneNumbers !=null ? new ObservableCollection<string>(dto.ListOfPhoneNumbers): new ObservableCollection<string>()
            };
        }

        public static ContactDto Map(ContactModel dto)
        {
            return new ContactDto()
            {
                Id = dto.Id,
                DateOfBirth = dto.DateOfBirth,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ListOfEmails = dto.ListOfEmails.ToList(),
                ListOfPhoneNumbers = dto.ListOfPhoneNumbers.ToList()
            };
        }
    }
}