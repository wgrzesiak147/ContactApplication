using System.Data.Entity;

namespace ContactApplication.Remote.Model
{
    public class PhoneDto
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public EntityState State { get; set; }
    }
}