namespace ProgramKadrowy_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetEmploymentDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmploymentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmploymentDate", c => c.DateTime(nullable: false));
        }
    }
}
