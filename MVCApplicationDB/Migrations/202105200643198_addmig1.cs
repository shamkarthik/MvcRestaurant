namespace MVCApplicationDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(nullable: false, maxLength: 1024),
                        ReviewerName = c.String(),
                        RestaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantReviews", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.RestaurantReviews", new[] { "RestaurantId" });
            DropTable("dbo.RestaurantReviews");
            DropTable("dbo.Restaurants");
        }
    }
}
