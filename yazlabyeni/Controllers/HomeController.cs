using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using yazlabyeni.Models;

namespace yazlabyeni.Controllers
{
  //  [Authorize(Roles ="User")]
    public class HomeController : Controller
    {

        TrainerManager trainerManager= new TrainerManager();

        public IActionResult Index()
        {
            var trainerList = trainerManager.GetAllTrainer();
            return View(trainerList);
        }
        public PartialViewResult TrainerList()
        {
            return PartialView();
        }
        public PartialViewResult SiteSlide()
        {
            return PartialView();
        }
        
    }
}