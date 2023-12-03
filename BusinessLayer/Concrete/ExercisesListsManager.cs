using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExercisesListsManager
    {
        Repository<ExerciseList> repository = new Repository<ExerciseList>();

        public List<ExerciseList> GetAllExercises()
        {
            return repository.List().ToList();
        }
        public ExerciseList GetExerciseByID(int id)
        {
            ExerciseList exerciseList = repository.Find(x=>x.ExerciseListId == id);
            return exerciseList;
        }
        public int Update(ExerciseList exerciseList)
        {
            ExerciseList exerciseList1 = repository.Find(x=>x.ExerciseListId==exerciseList.ExerciseListId);
            exerciseList1.Name = exerciseList.Name;
            exerciseList1.Target = exerciseList.Target;
            exerciseList1.ExerciseVideo = exerciseList.ExerciseVideo;
            exerciseList1.Set=exerciseList.Set;
            exerciseList1.Description = exerciseList.Description;
            return repository.Update(exerciseList1);
        }
        public int InsertExercise(ExerciseList exerciseList)
        {
            return repository.Insert(exerciseList);
        }
    }
}
