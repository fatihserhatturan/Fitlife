using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class UserManager
    {
        IUserDal userDal;
        Repository<User> repository = new Repository<User>();
        UserInfosManager userInfosManager = new UserInfosManager();

        public List<User> GetAllUsers()
        {
            return repository.List().ToList();
        }
        public User GetUSerById(int id)
        {
            User user = repository.Find(x=>x.UserId == id);
            return user;
        }

        public int InsertUser(User user)
        {
            user.Status = true;
            user.PhotoUrl = "a";
            user.Sex = "b";
            user.BirthDate = DateTime.Now;
            repository.Insert(user);
            userInfosManager.InsertUserInfo(user.UserId);
            return 0;
        }
        
        public int InsertRandomUser(User user)
        {
            repository.Insert(user);
            userInfosManager.InsertUserInfo(user.UserId);
            return 0;
        }

        public int Update(User user)
        {
            User UpdatedUser = repository.Find(x => x.UserId == user.UserId);
            UpdatedUser.Name = user.Name;
            UpdatedUser.Surname = user.Surname;
            UpdatedUser.PhoneNumber = user.PhoneNumber;
            UpdatedUser.BirthDate = user.BirthDate;
            UpdatedUser.Mail = user.Mail;
            UpdatedUser.Sex = user.Sex;
           
            return repository.Update(UpdatedUser);
        }
        public List<User> GetUsersByTrainerId(int id) 
        {
            UserManager um = new UserManager();
            UserTrainerManager userTrainerManager = new UserTrainerManager(new EfUserTrainerRepository());
            List<UserTrainer> userTrainers = userTrainerManager.GetUserTrainersByTrainerId(id);
            List<User> users = new List<User>();
            foreach (UserTrainer ut in userTrainers)
            {
                users.Add(um.GetUSerById(ut.UserID));
            }
            return users;
        }
        public User GetUserByEmail(string email)
        {
            return repository.Find(x => x.Mail==email);
        }

        public int ToggleUserStatus(int id)
        {
            User user = repository.Find(x => x.UserId == id);

            if(user.Status == false)
            {
                user.Status = true;
            }
            else
            {
                user.Status = false;
            }
            return repository.Update(user);
        }
    }
}
