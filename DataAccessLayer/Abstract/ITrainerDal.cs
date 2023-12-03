using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface ITrainerDal : IRepository<Trainer>
    {
        List<Trainer> GetAll();
    }
}
