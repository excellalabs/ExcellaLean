namespace Excella.Lean.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSsnToPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Ssn", c => c.String(maxLength: 9));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Ssn");
        }
    }
}
