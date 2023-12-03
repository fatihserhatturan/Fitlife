using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class ExercisesListsController : Controller
    {
        ExercisesListsManager exercisesListsManager = new ExercisesListsManager();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
          
            List<ExerciseList> exerciseLists = exercisesListsManager.GetAllExercises();
            return View(exerciseLists);
        }
        
        public IActionResult ExercisePage(int ExerciseListId)
        {
            ExerciseList exercise = exercisesListsManager.GetExerciseByID(ExerciseListId);
            return View(exercise);
        }
        public  IActionResult Update(ExerciseList exerciseList)
        {
            ExercisesListsManager exercisesListsManager = new ExercisesListsManager();
            exercisesListsManager.Update(exerciseList);
            return View(exerciseList);
        }
        public void AssignExercise(int UserId,int ExerciseListId,DateTime ExerciseDate)
        {
            ExerciseManager exerciseManager = new ExerciseManager(new EfExerciseRepository());
            var p = HttpContext.Session.GetString("AuthorMail");
            TrainerManager tm = new TrainerManager();
            Trainer trainer = tm.GetTrainerByEmail(p);
            
            Exercise exercise = new Exercise()
            {
                UserId=UserId,
                TrainerId=trainer.TrainerId,
                ExerciseListId=ExerciseListId,
                ExerciseDate=ExerciseDate,
            };
            exerciseManager.AddExercise(exercise);
           
        }

    }
}
