using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Chat.Database.MsSql.Context;
using Chat.Database.MsSql.Entities;
using Chat.Api.Constants;
using Microsoft.EntityFrameworkCore;
using Chat.Api.Core.Responses;
using Microsoft.AspNetCore.Authorization;
using IAuthorizationService = Chat.Api.Services.Interfaces.IAuthorizationService;
using Chat.Api.Domain.Users;
using System.Text.Json;
using Chat.Api.Core.Extentions;
using Chat.Api.Services;
using Chat.Api.Services.Interfaces;

namespace Chat.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IAuthorizationService AuthorizationService;
        public readonly IChatService ChatService;

        public UserController(ChatContext chatContext, IAuthorizationService authorizationService, IChatService chatService)
        {
            this.AuthorizationService = authorizationService;
            this.ChatService = chatService;
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            User user = await AuthorizationService.Register(model);
            return ResponseMethod.Success(new
            {
                token = AuthorizationService.GetToken(user)
            });
        }

        [HttpPost("authorize"), AllowAnonymous]
        public async Task<IActionResult> Authorize(AuthorizeModel model)
        {
            User user = await AuthorizationService.Authorize(model);
            return ResponseMethod.Success(new
            {
                token = AuthorizationService.GetToken(user),
            });
        }

        [HttpGet("chats")]
        public async Task<IActionResult> MyChats()
        {
            return ResponseMethod.Success(await ChatService.UserChats(User.Id()));
        }
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return ResponseMethod.Success(await ChatService.UserChatsPendings(User.Id()));
        }
    }
}
