namespace DDD.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddd001init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        About = c.String(),
                        Initiator_Name = c.String(),
                        Initiator_Position = c.String(),
                        ResponsibleId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        Urgency = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Position = c.String(),
                        HeadId = c.Guid(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.HeadId)
                .Index(t => t.HeadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "HeadId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "HeadId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Issues");
        }
    }
}
