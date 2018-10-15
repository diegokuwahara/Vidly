namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaodechaves : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MembershipTypeId");

            Sql("UPDATE Customers SET MembershipTypeId = 3 WHERE Id = 1");
            Sql("UPDATE Customers SET MembershipTypeId = 1 WHERE Id = 2");
            Sql("UPDATE Customers SET MembershipTypeId = 1 WHERE Id = 3");
            Sql("UPDATE Customers SET MembershipTypeId = 2 WHERE Id = 4");

            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Int());
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MembershipType_Id");
            CreateIndex("dbo.Movies", "Genre_Id");
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
