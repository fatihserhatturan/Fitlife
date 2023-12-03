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
    public class EfExerciseRepository : Repository<Exercise>, IExerciseDal
    {
        public List<Exercise> GetAll()
        {
            using (var c = new Context())
            {
                return c.Exercises
                    .Include(x=>x.ExerciseList)
                    .Include(x=>x.Trainer)
                    .Include(x=>x.User)
                    .ToList();
            }
        }
    }
}
