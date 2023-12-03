using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DietList
    {
        [Key]
        public int DietListId { get; set; }


        public int DailyCalories { get; set; }

        public string Target { get; set; }

        public string Breakfast { get; set; }

        public string Dinner { get; set; }

        public string Lunch { get; set; }

      
    }
}
