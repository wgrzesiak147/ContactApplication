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
                ListOfEmails = dto.ListOfEmails,
                ListOfPhoneNumbers = dto.ListOfPhoneNumbers
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
                ListOfEmails = dto.ListOfEmails,
                ListOfPhoneNumbers = dto.ListOfPhoneNumbers
            };
        }
    }
}