using BLL.DTO.UserTransfer;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ExtensionMethods.UserProfileExtension
{
    public static class UserProfileExtensionMethods
    {
        public static UesrProfile ToModel(this UserProfileDTO userProfileDTO)
        {
            var model = new UesrProfile
            {
                
                Email = userProfileDTO.Email,
                FristName = userProfileDTO.FristName,
                LastName = userProfileDTO.LastName,
                

            };return model;
        }
        public static UserProfileDTO ToView(this UesrProfile userProfileDTO)
        {
            var model = new UserProfileDTO
            {
                DateOfBirth = userProfileDTO.DateOfBirth,
                Email = userProfileDTO.Email,
                FristName = userProfileDTO.FristName,
                LastName = userProfileDTO.LastName,
                UserID = userProfileDTO.UserID,
                Posts = userProfileDTO.Posts.Where(i=>i.UserID==userProfileDTO.UserID).Select(i=>i.Title).ToArray(),

            }; return model;
        }

        public static UesrProfile ToAdd(this AddUserDTO addUserDTO)
        {

            var model = new UesrProfile
            {

                Email = addUserDTO.Email,
                FristName = addUserDTO.FristName,
                LastName = addUserDTO.LastName,
                DateOfBirth=addUserDTO.DateOfBirth


            }; return model;
        }
    }
}
