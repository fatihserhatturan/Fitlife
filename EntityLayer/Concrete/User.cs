
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public string HashedPassword { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string PhotoUrl { get; set; }
        public bool Status { get; set; }
    }
}
