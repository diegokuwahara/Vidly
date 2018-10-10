namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inserts : DbMigration
    {
        public override void Up()
        {
            /*
            Sql("INSERT INTO Customers(Name,isSubscribedToNewsLetter) VALUES ('Zé da Vala' ,true)");
            Sql("INSERT INTO Customers(Name,isSubscribedToNewsLetter) VALUES ('Leo doido',false)");
            Sql("INSERT INTO Customers(Name,isSubscribedToNewsLetter) VALUES ('Menino bom',false)");
            Sql("INSERT INTO Customers(Name,isSubscribedToNewsLetter) VALUES ('Xapatim',true)");
            */
            Sql("INSERT INTO Movies(Name) VALUES ('Propaganda Game')");
            Sql("INSERT INTO Movies(Name) VALUES ('Cannibal Holocaust')");
        }
        
        public override void Down()
        {
        }
    }
}
