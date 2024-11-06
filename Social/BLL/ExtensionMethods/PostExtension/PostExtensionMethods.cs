using BLL.DTO.PostTransfer;
using BLL.DTO.UserTransfer;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ExtensionMethods
{
    public static class PostExtensionMethods
    {
        public static Post ToModel(this PostDTO postDTO)
        {
            var PostToAdd = new Post
            {
                Title = postDTO.Title,
                Content = postDTO.Content,
                DatedPost = postDTO.DatedPost,
                UserID= postDTO.UserID,
            
              

            };
            return PostToAdd;

            
        }
        public static PostDTO ToView(this Post post)
        {
            var PostToAdd = new PostDTO
            {
                Title = post.Title,
                Content = post.Content,
                DatedPost = post.DatedPost,
                 PostID=post.PostID,
                 UserName=post.UesrProfiles.FristName+post.UesrProfiles.LastName,
                 UserID=post.UserID,


            };
            return PostToAdd;


        }
        public static Post ToAdd(this AddPostDTO addPost)
        {

            var model = new Post
            {

                Title = addPost.Title,
                Content = addPost.Content,
                UserID = addPost.UserID,
               


            }; return model;
        }
    }
}
