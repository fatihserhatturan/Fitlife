using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserTrainer
    {
        [Key]
        public int UserTrainerID { get; set; }
        public int UserID { get; set; }
        public int TrainerID { get; set; }

        public bool Status { get; set; }
        public User User { get; set; }
        public Trainer Trainer { get; set;}
    }
}
