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
    public class EfMessageRepository : Repository<Message>, IMessageDal
    {
        public List<Message> GetAll()
        {
            using (var c = new Context())
            {
                return c.Messages
                    .Include(x=>x.User)
                    .Include(x=>x.Trainer)
                    .ToList();
            }
        }
    }
}
