using System.Data.Entity;

namespace ContactApplication.Application.ViewModels
{
    public class PhoneNumberModel
    {
        public int Id { get; set; }


        public string Number { get; set; }

        public EntityState State { get; set; }
    }
}