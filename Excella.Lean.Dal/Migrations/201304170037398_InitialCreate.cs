namespace Excella.Lean.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ScheduledDate = c.DateTime(nullable: false),
                        LastUpdateBy = c.String(),
                        LastUpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        LastUpdateBy = c.String(),
                        LastUpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.ReservationResult",
                c => new
                    {
                        ReservationResultId = c.Int(nullable: false, identity: true),
                        LastUpdateBy = c.String(),
                        LastUpdateDate = c.DateTime(nullable: false),
                        ReservationRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationResultId)
                .ForeignKey("dbo.ReservationRequest", t => t.ReservationRequestId, cascadeDelete: true)
                .Index(t => t.ReservationRequestId);
            
            CreateTable(
                "dbo.ReservationRequest",
                c => new
                    {
                        ReservationRequestId = c.Int(nullable: false, identity: true),
                        RequestedBy = c.String(),
                        RequestedDate = c.String(),
                        LastUpdateBy = c.String(),
                        LastUpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationRequestId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ReservationResult", new[] { "ReservationRequestId" });
            DropForeignKey("dbo.ReservationResult", "ReservationRequestId", "dbo.ReservationRequest");
            DropTable("dbo.ReservationRequest");
            DropTable("dbo.ReservationResult");
            DropTable("dbo.Person");
            DropTable("dbo.Event");
        }
    }
}
