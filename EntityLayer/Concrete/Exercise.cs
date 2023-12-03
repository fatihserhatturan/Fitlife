using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Exercise
    {
        [Key]
        public int ExerciseID {  get; set; }
        public int TrainerId { get; set; }
        public int UserId { get; set; }
        public int ExerciseListId { get; set; }
        public DateTime ExerciseDate { get; set; }

        public bool Status { get; set; }
        public Trainer Trainer { get; set; }
        public User User { get; set; }
        public ExerciseList ExerciseList { get; set; }
    }
}
