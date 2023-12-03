using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace yazlabyeni.Controllers
{
    public class RegisterController : Controller
    {
        HashingManager HashingManager = new HashingManager();
        UserManager UserManager = new UserManager();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetRegister(User user)
        {
            user.HashedPassword = HashingManager.HashPassword(user.Password);
            UserManager.InsertUser(user);
            return RedirectToAction("Login","Login");
        }

    }
}
