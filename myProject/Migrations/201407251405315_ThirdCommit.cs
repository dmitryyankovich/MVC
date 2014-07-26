namespace myProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdCommit : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserLanguages");
            AddPrimaryKey("dbo.LanguagesUsers", new[] { "Languages_Id", "User_Id" });
            RenameTable(name: "dbo.UserLanguages", newName: "LanguagesUsers");
        }
    }
}
