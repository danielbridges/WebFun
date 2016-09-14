namespace LuresWebApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using LuresWebLib;
    using Models;

    public class HomeController : Controller
    {
        //https://gilesey.wordpress.com/2013/04/21/allowing-remote-access-to-your-iis-express-service

        public ActionResult Index()
        {
            var luresRepository = new LuresRepository();
            var allLures = luresRepository.Get();
            var lureDetails = allLures.Select(lure => new LureDetails
            {
                Id = lure.Id, 
                ImageUrl = lure.ImageUrl, Inventory = lure.Inventory, Caught = lure.Caught
            }).ToList();

            return View(lureDetails);
        }

        [HttpPost]
        public void UpdateCaughtAmount(int lureId, int caught)
        {
            var luresRepository = new LuresRepository();
            luresRepository.UpdateCaught(lureId, caught);
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