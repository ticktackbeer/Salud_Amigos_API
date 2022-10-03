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
        public async Task<ActionResult<IEnumerable<FriendModelDto>>> GetFriends([FromQuery] string email)
        {
            var result = await _friendService.GetFriends(email);
            return result.Select(x=> FriendModelDto.ToModel(x)).ToActionResult(x=>x);
        }

        /// <summary>
        /// Create a realationship
        /// </summary>
        /// <param name="friendDto">Friends properties</param>
        /// <returns>return friend object</returns>
        [HttpPost]
        [Route("createFriend")]
        public async Task<ActionResult<FriendModelDto> > CreateFriend([FromBody] FriendDto friendDto)
        {
            var result = await _friendService.CreateFriend(friendDto.UserId,friendDto.UserIdFriend, friendDto.Email,friendDto.EmailFriend,friendDto.FriendRequestId);
            return  FriendModelDto.ToModel(result).ToActionResult(x=> x);
            
        }


        /// <summary>
        /// Create a Friend request
        /// </summary>
        /// <param name="userAccount">User properties </param>
        /// <returns>return the number of saved operations</returns>
        [HttpPost]
        [Route("createFriendRequest")]
        public async Task<ActionResult<int>> CreateFriendRequest([FromBody] UserAccountRequestDto userAccount)
        {
            if(userAccount.UserAccount== null || userAccount.UserAccountFriend == null)
            {
                return NotFound();
            }
            var result = await _friendService.CreateFriendRequest(userAccount.UserAccount.ToModel(),userAccount.UserAccountFriend.ToModel());
            return result.ToActionResult(x=> x);

        }

        /// <summary>
        /// Get all Received Friends Request by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>All Friends Requests according to the Email</returns>
        [HttpGet]
        [Route("GetReceivedFriendRequest")]
        public async Task<ActionResult<IEnumerable<FriendRequestModelDto>>> GetReceivedFriendRequest([FromQuery] string email)
        {
            var result = await _friendService.GetReceivedFriendRequest(email);
            return result.Select(x=> FriendRequestModelDto.ToModel(x)).ToActionResult(x => x);
        }

        /// <summary>
        /// Get all Send Friends Request by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>All Friends Requests according to the Email</returns>
        [HttpGet]
        [Route("GetSendFriendRequest")]
        public async Task<ActionResult<IEnumerable<FriendRequestModelDto>>> GetSendFriendRequest([FromQuery] string email)
        {
            var result = await _friendService.GetSendFriendRequest(email);
            return result.Select(x => FriendRequestModelDto.ToModel(x)).ToActionResult(x => x);
        }
    }
}
