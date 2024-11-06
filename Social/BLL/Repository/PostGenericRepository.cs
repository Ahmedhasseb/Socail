using BLL.DTO.PostTransfer;
using BLL.ExtensionMethods;
using BLL.IRepository;
using DAL;
using DAL.Model;
using DAL.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class PostGenericRepository : IPostGenericRepository
    {
        private readonly IUniteOfWork _uniteOfWork;

        public PostGenericRepository(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public async Task AddPost(AddPostDTO Post)
        {
            if(Post != null)
            {
                var convert = Post.ToAdd();  
                    await _uniteOfWork.PostGenericRepository.Add(convert);
              await  _uniteOfWork.Commit();
                
            }
            
                
        }

        public async Task DeletPost(int PostId)
        {
            var postByRemove = await GetPostById(PostId);
            
            if (postByRemove != null)
            {
                postByRemove.State=EnumState.Deleted; 

                _uniteOfWork.PostGenericRepository.Update(postByRemove);
               await _uniteOfWork.Commit();

            }

        }

        public async Task<IEnumerable<PostDTO>> GetAllPost()
        {
            var AllPost =await _uniteOfWork.PostGenericRepository.GetAll();
            var WhereState = AllPost.Where(x => x.State != EnumState.Deleted);
            var ShowPostByDTO = WhereState.Select(x => x.ToView());
            return ShowPostByDTO;
        }

        public async Task<Post> GetPostById(int id)
        {
            var FindPost =await _uniteOfWork.PostGenericRepository.GetById(id);
            if (FindPost != null && FindPost.State==EnumState.Deleted)
                return null;
            
           
            return FindPost;
        }

        public async Task UpdatePost(int id, PostUpdateDTo Post)
        {
            var PostById = await GetPostById(id);
            
            if (PostById != null)
            {
                PostById.Title=Post.Title;
                PostById.Content=Post.Content;
                
                _uniteOfWork.PostGenericRepository.Update(PostById);
              await  _uniteOfWork.Commit();
            }
        }
        public async Task<IEnumerable<PostDTO>> GetAllPostsUser(int id)
        {
            
          var AllPosts= await _uniteOfWork.PostGenericRepository.GetAll();
            var AllPostWithUser = AllPosts.Where(x => x.UserID == id);
            var AllPost = AllPostWithUser.Where(x => x.State != EnumState.Deleted);
          var ShowPostsWithUser= AllPost.Select(x=>x.ToView()).ToList();
            return ShowPostsWithUser;
        }
    }
}
