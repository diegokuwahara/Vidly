namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class preencheNiver : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '10/12/1995' WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = '01/02/1900' WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
