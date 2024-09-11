using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKida.Entity;
using TechnologyKida.Repository.Interfaces;

namespace TechnologyKida.Repository.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task <UserInfo> GetUserInfo(string username, string password)
        {
            var user=await _context.userInfos.FirstOrDefaultAsync(
                x=>x.UserName.ToLower()==username.ToLower() 
                && x.Password==password);
            return user;
        }

        public async Task RegisterUser(UserInfo userInfo)
        {
            if (!Exists(userInfo.UserName))
            {
             await _context.userInfos.AddAsync(userInfo);
              await _context.SaveChangesAsync();
            }
          
        }

        private bool Exists(string userName)
        {
            return _context.userInfos.Any(x=>x.UserName.ToLower()==userName.ToLower());
        }
    }
}
