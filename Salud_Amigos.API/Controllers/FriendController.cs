using Microsoft.AspNetCore.Mvc;
using Salud_Amigos.Api.Dto;
using Salud_Amigos.Api.Helper;
using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Model;


namespace Salud_Amigos.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        public FriendController(IFriendService friendService)
        {
             _friendService= friendService;
        }

        /// <summary>
        /// Get all Friends by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>All Freinds according to the Email</returns>
        [HttpGet]
        [Route("GetFriends")]
        public async Task<ActionResult<List<FriendModel>>> GetFriend([FromQuery] string email)
        {

            var result = await _friendService.GetFriends(email);
            return result.ToActionResult(x => x);

        }

        /// <summary>
        /// Create an User
        /// </summary>
        /// <param name="userAccountDto">User properties</param>
        /// <returns>return createtd user</returns>
        [HttpPost]
        [Route("createFriend")]
        public async Task<ActionResult<FriendModel> > CreateFriend([FromBody] FriendDto friendDto)
        {
            var result = await _friendService.CreateFriend(friendDto.UserId,friendDto.UserIdFriend, friendDto.Email,friendDto.EmailFriend);
            return  result.ToActionResult(x=> x);
            
        }
    }
}
