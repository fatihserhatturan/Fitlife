using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfTrainerDietRepository : Repository<TrainerDiet>, ITrainerDietDal
    {
        public List<TrainerDiet> GetAll()
        {
            using (var c  = new Context())
            {
                return c.TrainerDiets
                    .Include(x=>x.DietList)
                    .Include(x=>x.Trainer)
                    .ToList();
            }
        }
    }
}
