using BLL.DTO.UserTransfer;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface IUserProfileRepository
    {
        public Task AddUser(AddUserDTO userProfile);
        public Task UpdateUser(int id,UserUpDateDTO userUpDateDTO);
        public Task DeletUser(int id);
        public Task<UesrProfile> GetUserById(int id);
        public Task<IEnumerable<UserProfileDTO>> GetAllUser();
    }
}
