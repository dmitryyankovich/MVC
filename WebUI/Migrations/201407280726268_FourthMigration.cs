namespace myProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Replies", "Id", c => c.Int(nullable: false));
        }
    }
}
