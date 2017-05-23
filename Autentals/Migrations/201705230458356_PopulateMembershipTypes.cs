namespace Autentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMonths, DiscountAmount) VALUES (0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMonths, DiscountAmount) VALUES (30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMonths, DiscountAmount) VALUES (90, 6, 15)");
            Sql("INSERT INTO MembershipTypes (SignUpFee, DurationInMonths, DiscountAmount) VALUES (300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
