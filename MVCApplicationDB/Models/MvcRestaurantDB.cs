using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCApplicationDB.Models
{
    public interface IMvcRestaurantDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }

    public class MvcRestaurantDb : DbContext, IMvcRestaurantDb
    {
        public MvcRestaurantDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        IQueryable<T> IMvcRestaurantDb.Query<T>()
        {
            return Set<T>();
        }

        void IMvcRestaurantDb.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IMvcRestaurantDb.Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IMvcRestaurantDb.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void IMvcRestaurantDb.SaveChanges()
        {
            SaveChanges();
        }
    }

}