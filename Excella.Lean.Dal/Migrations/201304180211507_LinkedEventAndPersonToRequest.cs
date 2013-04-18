namespace Excella.Lean.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkedEventAndPersonToRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReservationRequest", "RequestDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReservationRequest", "PersonId", c => c.Int(nullable: false));
            AddColumn("dbo.ReservationRequest", "EventId", c => c.Int(nullable: false));
            AddForeignKey("dbo.ReservationRequest", "PersonId", "dbo.Person", "PersonId", cascadeDelete: true);
            AddForeignKey("dbo.ReservationRequest", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
            CreateIndex("dbo.ReservationRequest", "PersonId");
            CreateIndex("dbo.ReservationRequest", "EventId");
            DropColumn("dbo.ReservationRequest", "RequestedBy");
            DropColumn("dbo.ReservationRequest", "RequestedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReservationRequest", "RequestedDate", c => c.String());
            AddColumn("dbo.ReservationRequest", "RequestedBy", c => c.String());
            DropIndex("dbo.ReservationRequest", new[] { "EventId" });
            DropIndex("dbo.ReservationRequest", new[] { "PersonId" });
            DropForeignKey("dbo.ReservationRequest", "EventId", "dbo.Event");
            DropForeignKey("dbo.ReservationRequest", "PersonId", "dbo.Person");
            DropColumn("dbo.ReservationRequest", "EventId");
            DropColumn("dbo.ReservationRequest", "PersonId");
            DropColumn("dbo.ReservationRequest", "RequestDate");
        }
    }
}
