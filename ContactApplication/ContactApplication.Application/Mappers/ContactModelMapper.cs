using System.Collections.ObjectModel;
using System.Linq;
using ContactApplication.Application.ViewModels;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Application.Mappers
{
    public class ContactModelMapper
    {
        public static ContactModel Map(ContactDto dto)
        {
            return new ContactModel
            {
                Id = dto.Id,
                DateOfBirth = dto.DateOfBirth,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ListOfEmails = dto.Emails != null
                    ? new ObservableCollection<EmailModel>(dto.Emails.Select(x =>
                        new EmailModel {Address = x.Address, Id = x.Id, State = x.State}))
                    : new ObservableCollection<EmailModel>(),
                ListOfPhoneNumbers = dto.PhoneNumbers != null
                    ? new ObservableCollection<PhoneNumberModel>(
                        dto.PhoneNumbers.Select(x => new PhoneNumberModel {Id = x.Id, Number = x.Number, State = x.State}))
                    : new ObservableCollection<PhoneNumberModel>()
            };
        }

        public static ContactDto Map(ContactModel model)
        {
            return new ContactDto
            {
                Id = model.Id,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Emails = model.ListOfEmails.Select(x => new EmailDto {Address = x.Address, Id = x.Id, State = x.State}).ToList(),
                PhoneNumbers = model.ListOfPhoneNumbers.Select(x => new PhoneDto {Number = x.Number, Id = x.Id, State = x.State})
                    .ToList()
            };
        }
    }
}