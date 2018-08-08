namespace ContactApplication.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCollectionUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.PhoneNumbers", new[] { "Contact_Id" });
            DropIndex("dbo.Emails", new[] { "Contact_Id" });
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Emails");
        }
    }
}
