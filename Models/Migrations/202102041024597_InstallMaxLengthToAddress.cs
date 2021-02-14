namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstallMaxLengthToAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Address", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Address", c => c.String());
        }
    }
}
