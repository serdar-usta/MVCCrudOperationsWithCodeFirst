namespace MvcCrudWithCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LessonEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lesson", "TeacherId", "dbo.Teacher");
            DropIndex("dbo.Lesson", new[] { "TeacherId" });
            DropTable("dbo.Lesson");
        }
    }
}
