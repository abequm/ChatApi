using Chat.Database.MsSql.Entities;

namespace Chat.Api.Domain.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public UserDTO(User user)
        {
            this.Id = user.Id;
            this.Nickname = user.Nick;
        }
    }
}
