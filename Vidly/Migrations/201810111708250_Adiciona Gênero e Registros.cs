namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaGêneroeRegistros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");

            Sql("INSERT INTO Genres(Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres(Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres(Name) VALUES ('Documentary')");
            Sql("INSERT INTO Genres(Name) VALUES ('Horror')");
            Sql("INSERT INTO Genres(Name) VALUES ('Action')");

            Sql("UPDATE Movies " +
                    "SET Genre_Id = 3, " +
                    "ReleaseDate = '10/10/2000', " +
                    "DateAdded = '11/10/2018', " +
                    "Stock = 5 " +
                    "WHERE Id = 1");
            Sql("UPDATE Movies " +
                    "SET Genre_Id = 4, " +
                    "ReleaseDate = '20/05/2010', " +
                    "DateAdded = '09/10/2018', " +
                    "Stock = 2 " +
                    "WHERE Id = 2");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.Genres");
        }
    }
}
