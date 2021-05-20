using MVCApplicationDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplicationDB.Controllers
{
    public class HomeController : Controller
    {
        IMvcRestaurantDb _db;
        //MvcRestaurantDb _db = new MvcRestaurantDb();
        public HomeController(IMvcRestaurantDb db)
        {
            _db = db;
        }
        public ActionResult Index(string searchTerm = null)
        {
            var model =
                _db.Restaurants
                   .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                   .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                   .Take(20)
                   .Select(r => new RestaurantListViewModel
                            {
                Id = r.Id,
                                Name = r.Name,
                                City = r.City,
                                Country = r.Country,
CountOfReviews = r.Reviews.Count()
                            }
                            );
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);


            }


            return View(model);

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            

            return View();
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
                               .Where(r => r.Name.StartsWith(term))
                               .Take(10)
                               .Select(r => new
                               {
                                   label = r.Name
                               });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}