using System.Data.Entity;
using ContactApplication.Database.Model;

namespace ContactApplication.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}