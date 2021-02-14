namespace WebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        From_UserId = c.Int(),
                        To_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.User", t => t.From_UserId)
                .ForeignKey("dbo.User", t => t.To_UserId)
                .Index(t => t.From_UserId)
                .Index(t => t.To_UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Photo = c.Byte(nullable: false),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "To_UserId", "dbo.User");
            DropForeignKey("dbo.Message", "From_UserId", "dbo.User");
            DropIndex("dbo.Message", new[] { "To_UserId" });
            DropIndex("dbo.Message", new[] { "From_UserId" });
            DropTable("dbo.User");
            DropTable("dbo.Message");
        }
    }
}
