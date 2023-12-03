namespace yazlabyeni.Models
{
    public class AddUserPhoto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public IFormFile PhotoUrl { get; set; }
    }
}
