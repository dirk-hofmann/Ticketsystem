namespace Ticketsystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerCompany : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "Customer_CompanyId", newName: "Company_CompanyId");
            RenameIndex(table: "dbo.Projects", name: "IX_Customer_CompanyId", newName: "IX_Company_CompanyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_Company_CompanyId", newName: "IX_Customer_CompanyId");
            RenameColumn(table: "dbo.Projects", name: "Company_CompanyId", newName: "Customer_CompanyId");
        }
    }
}
