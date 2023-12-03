namespace yazlabyeni.Models
{
    public class AddTrainerPhoto
    {

        public int TrainerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Expertise { get; set; }
        public int Count { get; set; }

        public IFormFile TrainerPhoto { get; set; }
    }
}
