namespace LuresWebApp.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using LuresWebLib;
    using Models;

    public class HomeController : Controller
    {
        private readonly LuresRepository luresRepository;

        public HomeController(LuresRepository luresRepository)
        {
            this.luresRepository = luresRepository;
        }

        //https://gilesey.wordpress.com/2013/04/21/allowing-remote-access-to-your-iis-express-service
        
        public ActionResult Index()
        {
            Console.WriteLine(HttpRuntime.AppDomainAppPath);

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
            luresRepository.UpdateCaught(lureId, caught);
        }

        [HttpPost]
        public void UpdateInventoryAmount(int lureId, int inventory)
        {
            luresRepository.UpdateInventory(lureId, inventory);
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