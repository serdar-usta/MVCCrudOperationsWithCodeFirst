namespace MvcCrudWithCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 200),
                        Body = c.String(nullable: false),
                        MessageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ReceiverId)
                .ForeignKey("dbo.User", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Message", "SenderId", "dbo.User");
            DropForeignKey("dbo.Message", "ReceiverId", "dbo.User");
            DropIndex("dbo.Message", new[] { "ReceiverId" });
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropTable("dbo.User");
            DropTable("dbo.Message");
        }
    }
}
