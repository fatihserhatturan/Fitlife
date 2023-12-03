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
    public class EfTrainerExerciseRepository : Repository<TrainerExercise>, ITrainerExerciseDal
    {
        public List<TrainerExercise> GetAll()
        {
            using(var c = new Context())
            {
                return c.TrainerExercises
                    .Include(x => x.ExerciseList)
                    .Include(x => x.Trainer)
                    .ToList();
            }
        }
    }
}
