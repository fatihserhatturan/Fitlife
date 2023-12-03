using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager
    {
        private readonly IMessageDal messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }

        public int InsertMessage(Message message)
        {
            return messageDal.Insert(message);
        }

        public List<Message> GetMessageByUser(int userId)
        {
            return messageDal.GetAll().Where(x => x.UserId == userId).ToList();
        }

    }
}
