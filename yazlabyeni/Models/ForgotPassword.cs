using System.ComponentModel.DataAnnotations;

namespace yazlabyeni.Models
{
    public class ForgotPassword
    {
        [Required, EmailAddress, Display(Name ="Email adresi:")]
        public string Email { get; set; }
        public string Code { get; set; } 
    }

}
