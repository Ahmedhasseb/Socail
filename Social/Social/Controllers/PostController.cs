using BLL.DTO.PostTransfer;
using BLL.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
       
        private readonly IPostGenericRepository _postGenericRepository;

        public PostController(IPostGenericRepository postGenericRepository)
        {
           _postGenericRepository = postGenericRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var AllPosts = await _postGenericRepository.GetAllPost();
            return Ok(new { status = 200, Data = AllPosts });

        }
        [HttpGet("GetPostByIdUser")]
        public async Task<ActionResult> GetAllPostsForUserById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var AllPostForUser = await _postGenericRepository.GetAllPostsUser(id);
            return Ok(new { status = 200, Data = AllPostForUser });

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdPost(int id)
        {
            if (!ModelState.IsValid && id == null)
                return BadRequest(ModelState);
            var GetByIdPost = await _postGenericRepository.GetPostById(id);
            return Ok(new { status = 200, Data = GetByIdPost });
        }


        [HttpPost("AddPost")]
        public async Task<ActionResult> AddPosts([FromBody] AddPostDTO postDTO)
        {
            if (!ModelState.IsValid && postDTO == null)
                return BadRequest(ModelState);
            await _postGenericRepository.AddPost(postDTO);
            return Ok(new { status = 200, Message = "Add To post Succes" });
        }

        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id, [FromBody] PostUpdateDTo postDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _postGenericRepository.UpdatePost(id, postDTO);
            return Ok(new { status = 200, Message = "Update To post Succes" });
        }

        // DELETE api/<UserProfileController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _postGenericRepository.DeletPost(id);
            return Ok(new { status = 200, Message = "Remove To post Succes" });
        }
    }
}
