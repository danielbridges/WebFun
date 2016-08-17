using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuresWebApp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
        //https://gilesey.wordpress.com/2013/04/21/allowing-remote-access-to-your-iis-express-service
            IEnumerable<LureDetails> lureDetails = new List<LureDetails>
            {
                new LureDetails
                {
                    Caught = 2,
                    Inventory = 1,
                    ImageUrl = @"~/content/images/img_4930.jpg"
                },
                new LureDetails
                {
                    Caught = 14,
                    Inventory = 2,
                    ImageUrl = @"~/content/images/img_4931.jpg"
                },
                new LureDetails
                {
                    Caught = 7,
                    Inventory = 8,
                    ImageUrl = @"~/content/images/img_4934.jpg"
                },
                new LureDetails
                {
                    Caught = 0,
                    Inventory = 1,
                    ImageUrl = @"~/content/images/img_4935.jpg"
                },
                new LureDetails
                {
                    Caught = 9,
                    Inventory = 3,
                    ImageUrl = @"~/content/images/img_4936.jpg"
                },
            };



            return View(lureDetails);
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
    }
}