namespace MVCApplicationDB.Migrations
{
    using MVCApplicationDB.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCApplicationDB.Models.MvcRestaurantDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCApplicationDB.Models.MvcRestaurantDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Restaurants.AddOrUpdate(r => r.Name,
new Restaurant { Name = "Annalakshmi", City = "Chennai", Country = "India" },
new Restaurant { Name = "RajDhani", City = "Ahmedabad", Country = "India" },
new Restaurant
{
    Name = "Carrots",
    City = "Bangalore",
    Country = "India",
    Reviews =
new List<RestaurantReview> {
        new RestaurantReview { Rating = 9, Body = "Great food!" }
}
            },
new Restaurant
{
    Name = "XYZ",
    City = "chennai",
    Country = "India",
    Reviews =
new List<RestaurantReview> {
        new RestaurantReview { Rating = 5, Body = "Delicious food!",ReviewerName="John" }
}
},
new Restaurant
{
    Name = "ABC",
    City = "Mumbai",
    Country = "India",
    Reviews =
new List<RestaurantReview> {
        new RestaurantReview { Rating = 8, Body = "superb!" }
}
}
);
            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = i.ToString(), City = "Somewhere", Country = "India" });
        }


    }
}
}
