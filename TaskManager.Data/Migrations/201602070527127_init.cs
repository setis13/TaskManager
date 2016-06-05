namespace TaskManager.Data.Context
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        EntityId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Important = c.Byte(nullable: false),
                        Hours = c.Double(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        EntityId = c.Guid(nullable: false),
                        Text = c.String(),
                        Status = c.Byte(nullable: false),
                        Progress = c.Byte(nullable: false),
                        Hours = c.Double(nullable: false),
                        TaskId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EntityId)
                .ForeignKey("dbo.Task", t => t.TaskId)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "TaskId", "dbo.Task");
            DropIndex("dbo.Comment", new[] { "TaskId" });
            DropTable("dbo.Comment");
            DropTable("dbo.Task");
        }
    }
}
