using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.ViewComponents
{
    public class TrainerDietList : ViewComponent
    {
        DietListsManager dietListsManager = new DietListsManager();
        public IViewComponentResult Invoke()
        {
           List<DietList> dietLists = dietListsManager.GetAllLists();
            return View(dietLists);
        }
    }
}
