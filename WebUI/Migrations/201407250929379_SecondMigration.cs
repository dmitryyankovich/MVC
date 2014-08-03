namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LanguagesUsers",
                c => new
                    {
                        Languages_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Languages_Id, t.User_Id })
                .ForeignKey("dbo.Languages", t => t.Languages_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Languages_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LanguagesUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LanguagesUsers", "Languages_Id", "dbo.Languages");
            DropIndex("dbo.LanguagesUsers", new[] { "User_Id" });
            DropIndex("dbo.LanguagesUsers", new[] { "Languages_Id" });
            DropTable("dbo.LanguagesUsers");
            DropTable("dbo.Languages");
        }
    }
}
