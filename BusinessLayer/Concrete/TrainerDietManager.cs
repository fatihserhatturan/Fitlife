using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TrainerDietManager
    {
        ITrainerDietDal trainerDietDal;

        public TrainerDietManager(ITrainerDietDal trainerDietDal)
        {
            this.trainerDietDal = trainerDietDal;
        }

        public List<TrainerDiet> GetDietByTrainer(int id)
        {
            return trainerDietDal.GetAll().Where(x => x.Trainer.TrainerId == id).ToList();
        }

        public int InsertDiet(int TrainerId, int DietListId)
        {

            if (trainerDietDal.Find(x => x.DietListId == DietListId && x.TrainerId == TrainerId) != null)
            {
                TrainerDiet trainerDiet = trainerDietDal.Find(x => x.DietListId == DietListId && x.TrainerId == TrainerId);
                trainerDiet.Status = true;
                return trainerDietDal.Update(trainerDiet);
            }

            else
            {
                TrainerDiet trainerDiet = new TrainerDiet
                {
                    TrainerId = TrainerId,
                    DietListId = DietListId,
                    Status = true
                };

                return trainerDietDal.Insert(trainerDiet);
            }

        }

        public int DeleteDiet(int TrainerId, int DietListId)
        {
            TrainerDiet trainerDiet = trainerDietDal.Find(x => x.DietListId == DietListId && x.TrainerId == TrainerId);
            trainerDiet.Status = false;

            return trainerDietDal.Update(trainerDiet);
        }
    }
}
