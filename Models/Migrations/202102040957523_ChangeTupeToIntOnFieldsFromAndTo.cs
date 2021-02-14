namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTupeToIntOnFieldsFromAndTo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Message", "From_UserId", "dbo.User");
            DropForeignKey("dbo.Message", "To_UserId", "dbo.User");
            DropIndex("dbo.Message", new[] { "From_UserId" });
            DropIndex("dbo.Message", new[] { "To_UserId" });
            AddColumn("dbo.Message", "From", c => c.Int(nullable: false));
            AddColumn("dbo.Message", "To", c => c.Int(nullable: false));
            DropColumn("dbo.Message", "From_UserId");
            DropColumn("dbo.Message", "To_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Message", "To_UserId", c => c.Int());
            AddColumn("dbo.Message", "From_UserId", c => c.Int());
            DropColumn("dbo.Message", "To");
            DropColumn("dbo.Message", "From");
            CreateIndex("dbo.Message", "To_UserId");
            CreateIndex("dbo.Message", "From_UserId");
            AddForeignKey("dbo.Message", "To_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Message", "From_UserId", "dbo.User", "UserId");
        }
    }
}
