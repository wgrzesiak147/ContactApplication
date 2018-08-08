using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Database.Model
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

    }
}
