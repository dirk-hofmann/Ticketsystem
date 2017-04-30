namespace Ticketsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.AspNetUsers", new[] { "Project_ProjectId" });
            CreateTable(
                "dbo.ProjectApplicationUsers",
                c => new
                    {
                        Project_ProjectId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_ProjectId, t.ApplicationUser_Id })
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Project_ProjectId)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.AspNetUsers", "Project_ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Project_ProjectId", c => c.Int());
            DropForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectApplicationUsers", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_ProjectId" });
            DropTable("dbo.ProjectApplicationUsers");
            CreateIndex("dbo.AspNetUsers", "Project_ProjectId");
            AddForeignKey("dbo.AspNetUsers", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
