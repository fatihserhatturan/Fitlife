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
    public class ExerciseManager
    {
        Repository<Exercise> repository= new Repository<Exercise>();
        IExerciseDal exerciseDal;

        public ExerciseManager(IExerciseDal exerciseDal)
        {
            this.exerciseDal = exerciseDal;
        }

        public List<Exercise> GetExercises()
        {
            return repository.List().ToList();
        }
        public Exercise GetExerciseById(int id)
        {
            Exercise exercise = repository.GetById(id);
            return exercise;
        }
        public Exercise GetExerciseByExercisesListsId(int id)
        {
            Exercise exercise = repository.Find(x=>x.ExerciseListId==id);
            return exercise;
        }
        public List<Exercise>  GetExercisesByTrainerId(int trainerId)
        {
           return exerciseDal.GetAll().Where(x=>x.TrainerId == trainerId).ToList();

        }
        public Exercise GetExercisesByUserId(int userId)
        {
            return repository.Find(x=>x.UserId == userId && x.Status == true);
        }
        public int AddExercise(Exercise exercise)
        {
            Exercise ex = exerciseDal.Find(x => x.ExerciseListId == exercise.ExerciseListId && x.UserId == exercise.UserId);

            if(ex.ExerciseListId !=null)
            {
                ex.Status = true;
                return exerciseDal.Update(ex);
            }
            else
            {
                return exerciseDal.Insert(exercise);
            }

        }

        public int DeleteExercise(Exercise exercise)
        {
            Exercise findExercise = exerciseDal.Find(x => x.ExerciseListId == exercise.ExerciseListId && x.UserId == exercise.UserId );

            if(findExercise.Status == true)
            {
                findExercise.Status = false;
                return exerciseDal.Update(findExercise);
            }
            else
            {
                return 0;
            }
        }
        
    }
}
