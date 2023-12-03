using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ExerciseList
    {
        [Key]
        public int ExerciseListId { get; set; }

        public string Target {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Set {  get; set; }
        public string ExerciseVideo { get; set; }
        
    }
}
