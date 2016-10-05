namespace MvcCrudWithCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Students", newName: "Student");
            RenameTable(name: "dbo.Teachers", newName: "Teacher");
            AlterColumn("dbo.Student", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Student", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Student", "DateOfBirth", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Teacher", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teacher", "LastName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Student", "FirstName", name: "IX_Student_FirstName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Student", "IX_Student_FirstName");
            AlterColumn("dbo.Teacher", "LastName", c => c.String());
            AlterColumn("dbo.Teacher", "FirstName", c => c.String());
            AlterColumn("dbo.Student", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Student", "LastName", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            RenameTable(name: "dbo.Teacher", newName: "Teachers");
            RenameTable(name: "dbo.Student", newName: "Students");
        }
    }
}
