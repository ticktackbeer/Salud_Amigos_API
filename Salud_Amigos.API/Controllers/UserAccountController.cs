﻿using Microsoft.AspNetCore.Mvc;
using Salud_Amigos.Api.Dto;
using Salud_Amigos.Api.Helper;
using Salud_Amigos.App.Interface;
using Salud_Amigos.App.Model;

namespace Salud_Amigos.Api.Controllers
{
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
        /// <param name="userAccountDto">User proberties</param>
        /// <returns>return createtd user</returns>
        [HttpPost]
        [Route("createUser")]
        public async Task<ActionResult<UserAccount> > CreateUserAccount([FromBody] UserAccountDto userAccountDto)
        {

            var result = await  _userAccountService.CreateUserAccount(userAccountDto.Email, userAccountDto.Token, userAccountDto.NickName, userAccountDto.Name, userAccountDto.Password, userAccountDto.Age);
            return  result.ToActionResult(UserAccountDto.FromModel);
            
        }


        

    }
}