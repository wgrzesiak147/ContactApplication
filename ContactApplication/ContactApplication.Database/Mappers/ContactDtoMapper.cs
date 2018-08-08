using System.Data.Entity;
using System.Linq;
using ContactApplication.Database.Model;
using ContactApplication.Interfaces.Model;

namespace ContactApplication.Database.Mappers
{
    public class ContactDtoMapper
    {
        public static Contact Map(ContactDto dto)
        {
            return new Contact
            {
                Id = dto.Id,
                DateOfBirth = dto.DateOfBirth,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Emails = dto.Emails.Select(x => new Email {Address = x.Address, Id = x.Id}).ToList(),
                PhoneNumbers = dto.PhoneNumbers.Select(x => new PhoneNumber {Id = x.Id, Number = x.Number}).ToList()
            };
        }

        public static ContactDto Map(Contact model)
        {
            return new ContactDto
            {
                Id = model.Id,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Emails = model.Emails
                    .Select(x => new EmailDto {Address = x.Address, Id = x.Id, State = EntityState.Unchanged}).ToList(),
                PhoneNumbers = model.PhoneNumbers.Select(x =>
                        new PhoneDto {Number = x.Number, Id = x.Id, State = EntityState.Unchanged})
                    .ToList()
            };
        }
    }
}