using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace yazlabyeni.ViewComponents
{
    public class TrainerAbout : ViewComponent
    {
        
        TrainerManager trainerManager = new TrainerManager();
        public IViewComponentResult Invoke(int id)
        {
            Trainer trainer = trainerManager.GetTrainerById(id);
            return View(trainer);
        }
    }
}
