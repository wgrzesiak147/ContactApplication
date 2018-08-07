using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Database.Model
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }


        public string Number { get; set; }
    }
}
