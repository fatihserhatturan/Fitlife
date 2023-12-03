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
    public class DietListsManager
    {
        Repository<DietList> repository = new Repository<DietList>();
        
        public List<DietList> GetAllLists()
        {
            return repository.List().ToList();
        }

        public DietList GetDietById(int id)
        {
            DietList diet = repository.Find(x => x.DietListId == id);

            return diet;
        }
        public DietList GetDietListByID(int id)
        {
            DietList dietlist = repository.Find(x=>x.DietListId == id);
            return dietlist;
        }
        public int Update(DietList dietlist)
        {
            DietList dietListUpdate = repository.Find(x => x.DietListId == dietlist.DietListId);
            dietListUpdate.DailyCalories = dietlist.DailyCalories;
            dietListUpdate.Target = dietlist.Target;
            dietListUpdate.Breakfast = dietlist.Breakfast;
            dietListUpdate.Dinner = dietlist.Dinner;
            dietListUpdate.Lunch = dietlist.Lunch;
            return repository.Update(dietListUpdate);
        }
        public int Insert(DietList dietlist)
        {
            return repository.Insert(dietlist);
        }
    }
}
