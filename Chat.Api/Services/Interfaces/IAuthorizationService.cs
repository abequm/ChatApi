using System.Security.Claims;

using Chat.Api.Domain.Users;
using Chat.Database.MsSql.Entities;

namespace Chat.Api.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<User> Register(RegisterModel model);
        public Task<User> Authorize(AuthorizeModel model);
        public string GetToken(User user);
    }
}
