﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCApplicationDB.Models
{
    public class MvcRestaurantDb : DbContext
    {
    public MvcRestaurantDb() : base("name=DefaultConnection")
    {

    }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<RestaurantReview> Reviews { get; set; }
}

}