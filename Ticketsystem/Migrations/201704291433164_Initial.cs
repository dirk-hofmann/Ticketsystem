namespace Ticketsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Payload = c.Binary(),
                        Ticket_TicketId = c.Int(),
                    })
                .PrimaryKey(t => t.AttachmentId)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketId)
                .Index(t => t.Ticket_TicketId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        EstimatedExpense = c.Time(nullable: false, precision: 7),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                        Ticket_TicketId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketId)
                .Index(t => t.Creator_Id)
                .Index(t => t.Ticket_TicketId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Company_CompanyId = c.Int(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Company_CompanyId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAdress = c.String(),
                        Postcode = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Customer_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Companies", t => t.Customer_CompanyId)
                .Index(t => t.Customer_CompanyId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Expense = c.Time(nullable: false, precision: 7),
                        Booker_Id = c.String(maxLength: 128),
                        Ticket_TicketId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.AspNetUsers", t => t.Booker_Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketId)
                .Index(t => t.Booker_Id)
                .Index(t => t.Ticket_TicketId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Bookings", "Ticket_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Bookings", "Booker_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attachments", "Ticket_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.AspNetUsers", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Customer_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Messages", "Ticket_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Messages", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Bookings", new[] { "Ticket_TicketId" });
            DropIndex("dbo.Bookings", new[] { "Booker_Id" });
            DropIndex("dbo.Projects", new[] { "Customer_CompanyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Project_ProjectId" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_CompanyId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Messages", new[] { "Ticket_TicketId" });
            DropIndex("dbo.Messages", new[] { "Creator_Id" });
            DropIndex("dbo.Tickets", new[] { "Project_ProjectId" });
            DropIndex("dbo.Attachments", new[] { "Ticket_TicketId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Bookings");
            DropTable("dbo.Projects");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Companies");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.Tickets");
            DropTable("dbo.Attachments");
        }
    }
}
