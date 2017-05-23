namespace Autentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedNewsletterToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedNewsletter");
        }
    }
}
