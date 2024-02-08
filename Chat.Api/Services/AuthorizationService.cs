using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Chat.Api.Constants;
using Chat.Api.Core.ExceptionsRequests;
using Chat.Api.Domain.Users;
using Chat.Api.Services.Interfaces;
using Chat.Database.MsSql.Context;
using Chat.Database.MsSql.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Chat.Api.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        public readonly ChatContext ChatContext;
        public readonly IChatService ChatService;
        public AuthorizationService(ChatContext chatContext, IChatService chatService)
        {
            this.ChatContext = chatContext;
            this.ChatService = chatService;
        }

        public async Task<User> Authorize(AuthorizeModel model)
        {
            var user = await ChatContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
            if (user is not null) return user;
            throw new NotFoundException("Не удалось авторизоваться", "Логин или пароль неверен");
        }

        public async Task<User> Register(RegisterModel model)
        {
            if (await UserExists(model.Login)) throw new AlreadyExistsException("Не удалось создать учетную запись", "Пользователь с таким логином уже существует.");
            User user = new()
            {
                Nick = model.Nickname,
                Login = model.Login,
                Password = model.Password,
                ChatAccesses = new List<ChatAccess>()
                {
                    new ChatAccess
                    {
                        ChatAccessStatus = Database.MsSql.Enums.ChatAccessStatus.Moderator,
                        Chat = new Database.MsSql.Entities.Chat
                        {
                            ChatType = Database.MsSql.Enums.ChatTypes.Favorite,
                            Title = "Избранное"
                        }
                    }
                }
            };
            await ChatContext.Users.AddAsync(user);
            await ChatContext.SaveChangesAsync();
            return user;
        }

        private async Task<bool> UserExists(string login) => await ChatContext.Users.AnyAsync(u => u.Login == login);

        public string GetToken(User user) => GenerateToken(user);

        private string GenerateToken(User user) => GenerateToken(GetIdentity(user));

        private static string GenerateToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
