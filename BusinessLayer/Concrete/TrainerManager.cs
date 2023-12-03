using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TrainerManager
    {
        Repository<Trainer> repository= new Repository<Trainer>();

        public List<Trainer> GetAllTrainer()
        {
            return repository.List().ToList();
        }

        public Trainer GetTrainerById(int Id) 
        {
            Trainer trainer = repository.Find(x=>x.TrainerId == Id);
            return trainer;
        }
        public int Insert(Trainer trainer)
        {
            return repository.Insert(trainer);
        }
        public int Update(Trainer trainer)
        {
            Trainer updatedTrainer = repository.Find(x=>x.TrainerId == trainer.TrainerId);
            updatedTrainer.Name = trainer.Name;
            updatedTrainer.Surname = trainer.Surname;
            updatedTrainer.PhoneNumber = trainer.PhoneNumber;
            updatedTrainer.Mail = trainer.Mail;
            updatedTrainer.Expertise = trainer.Expertise;
            updatedTrainer.Description = trainer.Description;

            return repository.Update(updatedTrainer);
        }
        public Trainer GetTrainerByEmail(string Email)
        {
            return repository.Find(x=>x.Mail == Email);
        }
        public int ToggleTrainerStatus(int id)
        {
            Trainer trainer = repository.Find(x => x.TrainerId == id);

            if (trainer.Status == false)
            {
                trainer.Status = true;
            }
            else
            {
                trainer.Status = false;
            }
            return repository.Update(trainer);
        }
    }
}
