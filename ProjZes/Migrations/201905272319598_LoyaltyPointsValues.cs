namespace ProjZes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoyaltyPointsValues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoyaltyValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fuel = c.Int(nullable: false),
                        Lpg = c.Int(nullable: false),
                        Washing = c.Int(nullable: false),
                        WashingPlusWaxing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO [dbo].[LoyaltyValues] ([Fuel], [Lpg], [Washing], [WashingPlusWaxing]) VALUES (100, 50, 300, 400)");
        }
        
        public override void Down()
        {
            DropTable("dbo.LoyaltyValues");
        }
    }
}
