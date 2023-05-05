namespace ProgramKadrowy_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncreasedContractsNameMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contracts", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contracts", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
