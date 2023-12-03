using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace yazlabyeni.ViewComponents
{
    
    public class TrainerExerciseList : ViewComponent
    {
        ExercisesListsManager exercisesListsManager = new ExercisesListsManager();

        
        public IViewComponentResult Invoke()
        {
            List<ExerciseList> exerciseLists = exercisesListsManager.GetAllExercises();
            return View(exerciseLists);
        }
    }
}
