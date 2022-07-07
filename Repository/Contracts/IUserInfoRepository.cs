using JWT.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Repository.Contracts
{
    public interface IUserInfoRepository
    {
        List<UserInfo> GetAllAsync();

        Task<UserInfo> GetByIdAsync(int id);

        Task<bool> AddUserInfoAsync(UserInfo userInfo);

        Task<bool> UpdateUserInfoAsync(UserInfo userInfo);

        Task<bool> DeleteUserInfo(int id);

        bool ExistsUserInfo(int id);
    }
}
