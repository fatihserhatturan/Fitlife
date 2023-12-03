using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Bogus;

namespace yazlabyeni.Controllers
{
    public class AdminController : Controller
    {
        UserManager userManager = new UserManager();
        TrainerManager trainerManager = new TrainerManager();
        ExercisesListsManager ExercisesListsManager = new ExercisesListsManager();
        DietListsManager DietListsManager = new DietListsManager();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserList()
        {
            var userlist = userManager.GetAllUsers();
            return View(userlist);
        }
        public IActionResult ToggleStatus(int userId)
        {
            try
            {
                userManager.ToggleUserStatus(userId);
                TempData["Message"] = "Durum başarıyla değiştirildi.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata: {ex.Message}";
            }

            return RedirectToAction("UserList");
        }

        public IActionResult TrainerList()
        {
            var trainerlist = trainerManager.GetAllTrainer();
            return View(trainerlist);
        }
        public IActionResult ToggleStatusTrainer(int userId)
        {
            try
            {
                trainerManager.ToggleTrainerStatus(userId);
                TempData["Message"] = "Durum başarıyla değiştirildi.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata: {ex.Message}";
            }

            return RedirectToAction("TrainerList");
        }

        public IActionResult ExerciseList()
        {
            var exerciselist = ExercisesListsManager.GetAllExercises();
            return View(exerciselist);
        }

        public IActionResult DietList()
        {

            var dietList = DietListsManager.GetAllLists();
            return View(dietList);

        }
        public IActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExercise(ExerciseList exerciseList)
        {
            ExercisesListsManager.InsertExercise(exerciseList);
            return RedirectToAction("AddExercise");
        }

        public IActionResult AddDiet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDiet(DietList dietList)
        {
            DietListsManager.Insert(dietList);
            return RedirectToAction("AddDiet");
        }

        public IActionResult GetExercise(int Id)
        {
            ExerciseList ex = ExercisesListsManager.GetExerciseByID(Id);
            return View(ex);
        }

        public IActionResult UpdateExercise(ExerciseList exerciseList)
        {
            ExercisesListsManager.Update(exerciseList);
            return RedirectToAction("ExerciseList");
        }
        public IActionResult GetDiet(int Id)
        {
            DietList dt = DietListsManager.GetDietListByID(Id);
            return View(dt);
        }

        public IActionResult UpdateDiet(DietList dietList)
        {
            DietListsManager.Update(dietList);
            return RedirectToAction("DietList");
        }

        public IActionResult AddRandomUser()
        {
            var faker = new Faker();
            var customizer = new Faker<User>("tr")
                .RuleFor(s => s.Name, f => f.Name.FirstName())
                .RuleFor(s => s.Surname, f => f.Name.LastName())
                .RuleFor(s => s.Mail, f => f.Internet.Email())
                .RuleFor(s => s.Password, f => f.Internet.Password())
                .RuleFor(s => s.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(s => s.BirthDate, f => f.Date.Past(18, DateTime.Now.AddYears(-10)))
                .RuleFor(s => s.PhotoUrl, f => f.Internet.Avatar())
                .RuleFor(s => s.Sex, f => "Erkek")
                .RuleFor(s => s.Status, f => true);

            User user =customizer.Generate();
            userManager.InsertRandomUser(user);

            return RedirectToAction("Index");
        }

        public IActionResult AddRandomTrainer()
        {
            var faker = new Faker();
            var customizer = new Faker<Trainer>("tr")
                .RuleFor(s => s.Name, f => f.Name.FirstName())
                .RuleFor(s => s.Surname, f => f.Name.LastName())
                .RuleFor(s => s.Mail, f => f.Internet.Email())
                .RuleFor(s => s.Password, f => f.Internet.Password())
                .RuleFor(s => s.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(s=>s.Expertise, f =>f.Company.CompanyName())
                .RuleFor(s => s.TrainerPhoto, f => f.Internet.Avatar())
                .RuleFor(s => s.Expertise, f => "Kas Kazanma")
                .RuleFor(s=>s.Count, f => 0)
                .RuleFor(s => s.Description, f => "trainer açıklama")
                .RuleFor(s => s.Status, f => true);

            Trainer trainer = customizer.Generate();
            trainerManager.Insert(trainer);

            return RedirectToAction("Index");
        }
    }
}
