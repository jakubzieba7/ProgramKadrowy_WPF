namespace ProgramKadrowy_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        ContractId = c.Int(nullable: false),
                        Comments = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmploymentDate = c.DateTime(nullable: false),
                        UnemploymentDate = c.DateTime(),
                        IsCurrentlyHired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ContractId", "dbo.Contracts");
            DropIndex("dbo.Employees", new[] { "ContractId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Contracts");
        }
    }
}
