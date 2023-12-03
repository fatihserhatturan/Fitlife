
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Trainer 
    {
        [Key]
        public int TrainerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Expertise { get; set; }
        public int Count { get; set; }
        public bool Status { get; set; }
        public string TrainerPhoto {  get; set; }

    }
}
