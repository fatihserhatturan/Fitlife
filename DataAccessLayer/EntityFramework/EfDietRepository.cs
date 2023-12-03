using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDietRepository : Repository<Diet>, IDietDal
    {
        public List<Diet> GetAll()
        {
            using (var c = new Context())
            {
                return c.Diets
                    .Include(x => x.Trainer)
                    .Include(x=>x.DietList)
                    .Include(x=>x.User)
                    .ToList();
                    
            }
        }
    }
}
