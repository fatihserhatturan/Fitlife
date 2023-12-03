using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Text {  get; set; }

        public int UserId { get; set; }

        public int TrainerId { get; set; }

        public User User { get; set; }

        public Trainer Trainer { get; set; }
    }
}
