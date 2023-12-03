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
    public class EfUserInfoRepository : Repository<UserInfo>, IUserInfoDal
    {
        public List<UserInfo> GetAll()
        {
            using (var c = new Context())
            {
                return c.UserInfos
                    .Include(x=>x.User)
                    .ToList();
            }
        }
    }
}
