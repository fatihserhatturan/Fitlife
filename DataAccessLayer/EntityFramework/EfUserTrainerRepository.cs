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
    public class EfUserTrainerRepository : Repository<UserTrainer>, IUserTrainerDal
    {
        public List<UserTrainer> GetAll()
        {
            using(var c = new Context())
            {
                return c.UserTrainers
                    .Include(x=>x.Trainer)
                    .Include(x=>x.User)
                    .ToList();
            }
        }
    }
}
