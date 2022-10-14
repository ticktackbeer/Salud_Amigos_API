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
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        /// <summary>
        /// Create an User
        /// </summary>
        /// <param name="userAccountDto">User properties</param>
        /// <returns>return createtd user</returns>
        [HttpPost]
        [Route("createUser")]
        public async Task<ActionResult<SingleUserAccountModelDto> > CreateUserAccount([FromBody] UserAccountDto userAccountDto)
        {

            var result = await  _userAccountService.CreateUserAccount(userAccountDto.Email, userAccountDto.Token, userAccountDto.NickName, userAccountDto.Name, userAccountDto.Password, userAccountDto.Age);
            return result.ToActionResult(SingleUserAccountModelDto.ToModel);
            
        }

        /// <summary>
        /// Get User by Emails
        /// </summary>
        /// <param name="email">Emails to search the user</param>
        /// <returns>return a list of users</returns>
        [HttpGet]
        [Route("GetUsersByEmail")]
        public async Task<ActionResult<List<SingleUserAccountModelDto>>> GetUsersByEmail([FromQuery] List<string> email)
        {

            var result = await _userAccountService.GetUsersByEmail(email);
            return result.ToActionResult(SingleUserAccountModelDto.ToModel);

        }

        /// <summary>
        /// Get a User by Search String
        /// </summary>
        /// <param name="searchText"> String to search the user</param>
        /// <returns>return a list of users</returns>
        [HttpGet]
        [Route("GetUsersBySearchText")]
        public async Task<ActionResult<List<SingleUserAccountModelDto>>> GetUsersBySearchText([FromQuery] string searchText)
        {
            var result = await _userAccountService.GetUsersBySearchText(searchText);
            return result.ToActionResult(SingleUserAccountModelDto.ToModel);

        }

        /// <summary>
        /// Delete an User
        /// </summary>
        /// <param name="userId">Id of the user to be deleted</param>
        /// <returns>return number of deleted rows</returns>
        [HttpDelete]
        [Route("DeleteUserByUserId")]
        public async Task<ActionResult> DeleteUser([FromQuery] Guid userId)
        {
            var result = await _userAccountService.DeleteUserById(userId);
            return result.ToActionResult();

        }




    }
}
