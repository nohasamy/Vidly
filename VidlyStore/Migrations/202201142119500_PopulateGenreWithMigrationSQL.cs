namespace VidlyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreWithMigrationSQL : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Horror')");
            Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            Sql("INSERT INTO Genres (Name) VALUES ('Fantasy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Mystery')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
