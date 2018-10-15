namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inserts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name) VALUES ('Propaganda Game')");
            Sql("INSERT INTO Movies(Name) VALUES ('Cannibal Holocaust')");

            Sql("INSERT INTO MembershipTypes(DiscountRate,DurationInMonths,Name,SignUpFee) VALUES (10, 3, 'Three Months', 30)");
            Sql("INSERT INTO MembershipTypes(DiscountRate,DurationInMonths,Name,SignUpFee) VALUES (15, 6, 'Half Year', 60)");
            Sql("INSERT INTO MembershipTypes(DiscountRate,DurationInMonths,Name,SignUpFee) VALUES (30, 12, 'Whole Year', 100)");

            Sql("INSERT INTO Customers(Name,isSubscribedToNewsLetter,MembershipType_Id) VALUES ('Zé da Vala' ,1,3)");
            Sql("INSERT INTO Customers(Name,isSubscribedToNewsLetter,MembershipType_Id) VALUES ('Leo doido',1,1)");
            Sql("INSERT INTO Customers(Name,isSubscribedToNewsLetter,MembershipType_Id) VALUES ('Menino bom',0,1)");
            Sql("INSERT INTO Customers(Name,isSubscribedToNewsLetter,MembershipType_Id) VALUES ('Xapatim',0,2)");
        }

        public override void Down()
        {
        }
    }
}
