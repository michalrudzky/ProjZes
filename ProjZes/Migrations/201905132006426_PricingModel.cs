namespace ProjZes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PricingModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarWashPricings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Washing = c.Single(nullable: false),
                        Waxing = c.Single(nullable: false),
                        WashingAndWaxing = c.Single(nullable: false),
                        Polishing = c.Single(nullable: false),
                        WashingAndWaxingAndPolishing = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FuelPricings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pb95 = c.Single(nullable: false),
                        Pb98 = c.Single(nullable: false),
                        Diesel = c.Single(nullable: false),
                        Lpg = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FuelPricings");
            DropTable("dbo.CarWashPricings");
        }
    }
}
