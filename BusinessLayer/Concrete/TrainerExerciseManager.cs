using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TrainerExerciseManager
    {
        ITrainerExerciseDal trainerExerciseDal;

        public TrainerExerciseManager(ITrainerExerciseDal trainerExerciseDal)
        {
            this.trainerExerciseDal = trainerExerciseDal;
        }

        public List<TrainerExercise> GetTrainerExerciseById(int id)
        {
            return trainerExerciseDal.GetAll().Where(x => x.Trainer.TrainerId == id).ToList();
        }

        public int InsertExercise(int TrainerId, int ExerciseListId)
        {

            if (trainerExerciseDal.Find(x => x.ExerciseListId == ExerciseListId && x.TrainerId == TrainerId) != null)
            {
                TrainerExercise trainerExercise = trainerExerciseDal.Find(x => x.ExerciseListId == ExerciseListId && x.TrainerId == TrainerId);
                trainerExercise.Status = true;
                return trainerExerciseDal.Update(trainerExercise);
            }

            else
            {
                TrainerExercise trainerExercise = new TrainerExercise
                {
                    TrainerId = TrainerId,
                    ExerciseListId = ExerciseListId,
                    Status = true
                };

                return trainerExerciseDal.Insert(trainerExercise);
            }

        }

        public int DeleteExercise(int TrainerId, int ExerciseListId)
        {
            TrainerExercise trainerExercise = trainerExerciseDal.Find(x => x.ExerciseListId == ExerciseListId && x.TrainerId == TrainerId);
            trainerExercise.Status = false;

            return trainerExerciseDal.Update(trainerExercise);
        }
    }
}
