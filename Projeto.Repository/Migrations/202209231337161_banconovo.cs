using System.Data.Entity.Migrations;

public partial class banconovo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maintenance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Stage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaintenanceId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        Status = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        Value = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maintenance", t => t.MaintenanceId, cascadeDelete: true)
                .Index(t => t.MaintenanceId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Maintenance", "UserId", "dbo.Users");
            DropForeignKey("dbo.Stage", "MaintenanceId", "dbo.Maintenance");
            DropIndex("dbo.Stage", new[] { "MaintenanceId" });
            DropIndex("dbo.Maintenance", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Stage");
            DropTable("dbo.Maintenance");
        }
    }

