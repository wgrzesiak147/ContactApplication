using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ContactApplication.Database.Model
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }


        public string Number { get; set; }

        [NotMapped]
        public EntityState State { get; set; }
    }
}