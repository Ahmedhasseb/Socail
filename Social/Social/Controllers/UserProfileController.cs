using BLL.DTO.UserTransfer;
using BLL.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Social.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
       
        [HttpGet]
        public async  Task<ActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var AllUsers = await _userProfileRepository.GetAllUser();
            return Ok(new {status=200,Data=AllUsers});

        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdUser(int id)
        {
            if (!ModelState.IsValid &&id == null)
               return BadRequest(ModelState);
            var GetByIdUser =await _userProfileRepository.GetUserById(id);
            return Ok(new { status = 200, Data = GetByIdUser });
        }

        
        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUsers([FromBody]AddUserDTO userProfile)
        {
            if (!ModelState.IsValid && userProfile==null)
                return BadRequest(ModelState);
            await _userProfileRepository.AddUser(userProfile);
            return Ok(new {Status=200,Message="Add To User Sccuss"});
        }

       
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsers(int id, [FromBody] UserUpDateDTO userUpDateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           await _userProfileRepository.UpdateUser(id,userUpDateDTO);
            return Ok(new { status=200,Message= "Update user Succes" });
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           await _userProfileRepository.DeletUser(id);
            return new JsonResult("Delet User Sucss");
        }
    }
}
