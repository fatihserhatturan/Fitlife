using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Diet
    {
        [Key]
        public int DietId { get; set; }

        public int UserId { get; set; }
        public int TrainerId { get; set; }

        public int DietListId { get; set; }

        public bool Status { get; set; }
        public User User { get; set; }

        public Trainer Trainer { get; set;}

        public DietList DietList { get; set; }
    }
}
