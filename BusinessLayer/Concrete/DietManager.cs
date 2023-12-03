using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DietManager
    {
        Repository<Diet> repository= new Repository<Diet>();
        IDietDal dietDal;

        public DietManager(IDietDal dietDal)
        {
            this.dietDal = dietDal;
        }

        public List<Diet> GetDiets()
        {
            return repository.List().ToList();
        }
        public Diet GetDietById(int id)
        {
            Diet diet = repository.GetById(id);
            return diet;
        }
        public Diet GetDietByDietListID(int dietListID)
        {
            Diet diet = repository.Find(x=>x.DietListId == dietListID);
            return diet;
        }
        public List<Diet> GetDietsByTrainerId(int trainerId)
        {
            return dietDal.GetAll().Where(x=>x.TrainerId == trainerId).ToList();
        }
        public Diet GetDietsByUserId(int userId)
        {
            return repository.Find(x=> x.UserId == userId && x.Status == true);
        }
        public int AddDiet(Diet diet)
        {
            Diet dt = dietDal.Find(x=>x.DietListId == diet.DietListId && x.UserId == diet.UserId);

            if (dt != null)
            {
                dt.Status = true;
                return dietDal.Update(dt);
            }
            else
            {
                return dietDal.Insert(diet);
            }

        }

        public int DeleteDiet(Diet diet)
        {
            Diet findDiet = dietDal.Find(x => x.DietListId == diet.DietListId && x.UserId == diet.UserId);

            if (findDiet.Status == true)
            {
                findDiet.Status = false;
                return dietDal.Update(findDiet);
            }
            else
            {
                return 0;
            }
        }
    }
}
