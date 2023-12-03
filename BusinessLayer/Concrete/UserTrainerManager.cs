using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserTrainerManager
    {
        IUserTrainerDal UserTrainerDal;
        Repository<UserTrainer> repository = new Repository<UserTrainer>();

        public UserTrainerManager(IUserTrainerDal userTrainerDal)
        {
            UserTrainerDal = userTrainerDal;
        }

        public List<UserTrainer> GetUserTrainersByTrainerId(int id)
        {
            return  UserTrainerDal.GetAll().Where(x=>x.TrainerID==id).ToList();
        }
        public UserTrainer GetUserTrainerByUser(int id)
        {
            return UserTrainerDal.Find(x => x.UserID == id);
        }

        public int InsertUserTrainer(UserTrainer userTrainer)
        {
            return UserTrainerDal.Insert(userTrainer);
        }

        public int StatusChangeTrue(int Id)
        {
            UserTrainer userTrainer = UserTrainerDal.Find(x=>x.UserTrainerID==Id);
            userTrainer.Status = true;

            return UserTrainerDal.Update(userTrainer);
        }

        public int StatusChangeFalse(int Id)
        {
            UserTrainer userTrainer = UserTrainerDal.Find(x => x.UserTrainerID == Id);
            userTrainer.Status = false;

            return UserTrainerDal.Update(userTrainer);
        }
    }
}
