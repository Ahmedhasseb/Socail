using BLL.DTO.PostTransfer;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface IPostGenericRepository
    {
        public Task AddPost(AddPostDTO Post);
        public Task UpdatePost(int id, PostUpdateDTo Post);
        public Task DeletPost(int PostId);
        public Task<Post> GetPostById(int id);
        public Task<IEnumerable<PostDTO>> GetAllPostsUser(int id);
        public Task<IEnumerable<PostDTO>> GetAllPost();
    }
}
