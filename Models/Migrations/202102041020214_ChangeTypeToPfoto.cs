namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeToPfoto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Photo", c => c.Byte());
        }
    }
}
