namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLognToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Login", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Login");
        }
    }
}
