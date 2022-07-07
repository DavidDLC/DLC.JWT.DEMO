using JWT.Models.Data;
using JWT.Models.Models;
using JWT.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Repository.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly JWTAuthenticationContext _context;

        public UserInfoRepository(JWTAuthenticationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserInfoAsync(UserInfo userInfo)
        {
            await _context.UserInfos.AddAsync(userInfo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserInfo(int id)
        {
            UserInfo? userInfoEntity = await _context.UserInfos.FindAsync(id);

            if (userInfoEntity == null) throw new ArgumentNullException();

            _context.UserInfos.Remove(userInfoEntity);

            return await _context.SaveChangesAsync() > 0;
        }

        public bool ExistsUserInfo(int id)
        {
            return _context.Employees.Any(q => q.EmployeeId == id);
        }

        public List<UserInfo> GetAllAsync()
        {
            return _context.UserInfos.ToList();
        }

        public async Task<UserInfo> GetByIdAsync(int id)
        {
            return await _context.UserInfos.FindAsync(id);
        }

        public async Task<bool> UpdateUserInfoAsync(UserInfo userInfo)
        {
            _context.Entry(userInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
