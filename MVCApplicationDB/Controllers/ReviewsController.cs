using MVCApplicationDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplicationDB.Controllers
{
    public class ReviewsController : Controller
    {
        MvcRestaurantDb _db = new MvcRestaurantDb();

        public ActionResult Index([Bind(Prefix = "id")] int restauarntId)
        {
            var model = _db.Restaurants.Find(restauarntId);
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();

        }
        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            RestaurantReview r = new RestaurantReview();
            r.RestaurantId = restaurantId;
            return View(r);
        }

        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }
            return View(review);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}