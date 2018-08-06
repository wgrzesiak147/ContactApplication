using ContactApplication.Database.Model;

namespace ContactApplication.Database
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
    }

}