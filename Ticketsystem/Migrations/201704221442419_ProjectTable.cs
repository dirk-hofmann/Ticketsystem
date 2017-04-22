namespace Ticketsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            AddColumn("dbo.Tickets", "Title", c => c.String());
            AddColumn("dbo.Tickets", "Project_ProjectId", c => c.Int());
            CreateIndex("dbo.Tickets", "Project_ProjectId");
            AddForeignKey("dbo.Tickets", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Tickets", new[] { "Project_ProjectId" });
            DropColumn("dbo.Tickets", "Project_ProjectId");
            DropColumn("dbo.Tickets", "Title");
            DropTable("dbo.Projects");
        }
    }
}
