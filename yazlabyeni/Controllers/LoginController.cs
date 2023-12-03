using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using yazlabyeni.Models;

namespace yazlabyeni.Controllers
{
    public class LoginController : Controller
    {

        HashingManager hashingManager = new HashingManager();
        UserManager userManager = new UserManager();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name,"UserSession"),
                new Claim(ClaimTypes.Role,"User")
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authproperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authproperties);
            Context context = new Context();

            string hashedpassword = userManager.GetUserByEmail(user.Mail).HashedPassword;

            // bool VerifyPassword = hashingManager.VerifyPassword(user.Password,hashedpassword);

            bool VerifyPassword = true;
            var userinfo = context.Users.FirstOrDefault(x => x.Mail == user.Mail && x.Password == user.Password && x.Status == true);

            if (userinfo != null || VerifyPassword == true)
            {
                HttpContext.Session.SetString("Mail", user.Mail);
                return RedirectToAction("Index", "User");
            }
            
            return View();
        }  

        [HttpGet]
        public IActionResult TrainerLogin()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> TrainerLogin(Trainer trainer)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name,"TrainerSession"),
                new Claim(ClaimTypes.Role,"Trainer")
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authproperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authproperties);
            Context context = new Context();

            var userinfo = context.Trainers.FirstOrDefault(x => x.Mail == trainer.Mail && x.Password == trainer.Password && x.Status == true);

            if (userinfo != null)
            {
                HttpContext.Session.SetString("Mail", trainer.Mail);
                return RedirectToAction("Index", "Trainer");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AdminLogin(Admin admin)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name,"AdminSession"),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authproperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authproperties);
            Context context = new Context();

            var userinfo = context.Admins.FirstOrDefault(x => x.Name == admin.Name && x.Password == admin.Password);

            if (userinfo != null)
            {
                HttpContext.Session.SetString("Name", admin.Name);
                return RedirectToAction("UserList", "Admin");
            }
            
            return View();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


       // [AllowAnonymous, HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous, HttpPost("forgot-password")]
        public IActionResult ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();


            }
            return View();
        }

        public void MailSender(IFormCollection formCollection)
        {
            try
            {
                Singleton singleton = Singleton.GetInstance();
                ForgotPassword model = new ForgotPassword();
                Random random = new Random();
                string directionMail = formCollection["Email"];
                string fromAddress = "ms.srml.8769@gmail.com";
                string password = "slzb hhif xcgl cptm";
                string subject = (random.Next(1000, 10000)).ToString();
                model.Email = directionMail;
                model.Code = subject;
                string body = "<p>Şifreni sıfırlamak için gereken kod:</p>" + subject;
                // SMTP sunucu ve port bilgileri
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                singleton.mail = directionMail;
                singleton.code = subject;
                // MailMessage oluştur
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(directionMail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                // SmtpClient oluştur ve e-postayı gönder
                using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(fromAddress, password);
                    smtpClient.EnableSsl = true; // SSL kullanılıyorsa true, kullanılmıyorsa false

                    smtpClient.Send(mail);
                }

                ViewBag.Message = "E-posta başarıyla gönderildi.";

            }
            catch (Exception ex)
            {
                ViewBag.Error = $"E-posta gönderilirken bir hata oluştu: " + ex.Message;

            }
        }
        public IActionResult CheckCode(IFormCollection formCollection)
        {
            Singleton singleton = Singleton.GetInstance();
            string text;

            string UserCode = formCollection["Code"];
            Console.WriteLine(UserCode);
            if (UserCode == singleton.code)
            {
                string newPass = GenerateRandomPassword(8);
                text = "Şifreniz değişti, yeni şifreniz: " + newPass;

                updateDatabase(newPass);
            }
            else
            {
                text = "Yanlış kod girdiniz";
            }
            var response = new { text = text };
            return Json(response);
        }
        public void updateDatabase(string password)
        {
            Singleton singleton = Singleton.GetInstance();
            TrainerManager trainerManager = new TrainerManager();
            UserManager userManager = new UserManager();
            List<User> users = userManager.GetAllUsers();
            List<Trainer> trainers = trainerManager.GetAllTrainer();
            foreach (User user in users)
            {
                if (singleton.mail == user.Mail)
                {
                    user.Password = password;
                    userManager.Update(user);
                }

            }
            foreach (Trainer trainer in trainers)
            {
                if (singleton.mail == trainer.Mail)
                {
                    trainer.Password = password;
                    trainerManager.Update(trainer);
                }
            }
        }
        static string GenerateRandomPassword(int length)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            char[] password = new char[length];

            for (int i = 0; i < length; i++)
            {
                password[i] = characters[random.Next(characters.Length)];
            }

            return new string(password);
        }
    }
}
