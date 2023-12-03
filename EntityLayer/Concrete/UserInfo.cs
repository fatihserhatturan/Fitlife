using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Weight { get; set; }

        public string Height { get; set; }

        public string FatRate { get; set; }

        public int WeeklyCalories { get; set; }

        public User User { get; set; }  
    }
}
