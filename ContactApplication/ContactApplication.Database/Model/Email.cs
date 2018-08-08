using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ContactApplication.Database.Model
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        [NotMapped]
        public EntityState State { get; set; }
    }
}