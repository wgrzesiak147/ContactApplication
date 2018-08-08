using System.Data.Entity;

namespace ContactApplication.Interfaces.Model
{
    public class EmailDto
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public EntityState State { get; set; }
    }
}