using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKida.Entity;

namespace TechnologyKida.Repository.Interfaces
{
    public interface IUserRepo
    {
        Task RegisterUser(UserInfo userInfo);
       Task<UserInfo> GetUserInfo(string username, string password);

    }
}
