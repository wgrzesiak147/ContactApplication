using System.Data.Entity;

namespace ContactApplication.Application.ViewModels
{
    public class EmailModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public EntityState State { get; set; }
    }
}