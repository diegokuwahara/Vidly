namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class free_membership : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(DiscountRate,DurationInMonths,Name,SignUpFee) VALUES (0, 12, 'Free Sign-Up', 0)");
        }
        
        public override void Down()
        {
        }
    }
}
