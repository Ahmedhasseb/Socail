using BLL.DTO.UserTransfer;
using BLL.ExtensionMethods.UserProfileExtension;
using BLL.IRepository;
using DAL.Model;
using DAL.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class UserProfileGenericRepository : IUserProfileRepository
    {
        private readonly IUniteOfWork _uniteOfWork;

        public UserProfileGenericRepository(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public async Task AddUser(AddUserDTO userProfile)
        {
            if (userProfile!=null)
            {
                var ConvertToUser=userProfile.ToAdd();
               await _uniteOfWork.UserGenericRepository.Add(ConvertToUser);
                await _uniteOfWork.Commit();
            }
        }

        public async Task DeletUser(int  id)
        {
            var GetOneUser = await GetUserById(id);
            
            if ( GetOneUser!=null)
            {
                GetOneUser.State = EnumState.Deleted;
                _uniteOfWork.UserGenericRepository.Update(GetOneUser);
               await _uniteOfWork.Commit();
            }
        }

        public async Task<IEnumerable<UserProfileDTO>> GetAllUser()
        {
            var ConvertToUser=await _uniteOfWork.UserGenericRepository.GetAll();
            var GetAllUser = ConvertToUser.Where(x => x.State != EnumState.Deleted);
            var ConvertToDTO = GetAllUser.Select(i => i.ToView());
            return ConvertToDTO;    
        }

        public async Task<UesrProfile> GetUserById(int id)
        {
              var ConvertToUser=await _uniteOfWork.UserGenericRepository.GetById(id);
            if (ConvertToUser != null&& ConvertToUser.State == EnumState.Deleted)
      
                    return null;
     
            var ConvertToDTo = ConvertToUser.ToView();

            return ConvertToUser;

        }

        public async Task UpdateUser(int id, UserUpDateDTO userUpDateDTO)
        {
            var getUesrId = await GetUserById(id);
           
            if(getUesrId !=null &&userUpDateDTO != null)
            {
                getUesrId.FristName = userUpDateDTO.FristName;
                getUesrId.LastName=userUpDateDTO.LastName;
                getUesrId.Email=userUpDateDTO.Email;
                
                _uniteOfWork.UserGenericRepository.Update(getUesrId);
               await _uniteOfWork.Commit();
            }
        }
    }
}
