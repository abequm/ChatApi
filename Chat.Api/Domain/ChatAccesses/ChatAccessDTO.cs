using Chat.Api.Domain.Chats;
using Chat.Api.Domain.Users;
using Chat.Database.MsSql.Entities;
using Chat.Database.MsSql.Enums;

namespace Chat.Api.Domain.ChatAccesses
{
    public class ChatAccessDTO
    {
        public UserDTO User { get; set; }
        public ChatDTO Chat { get; set; }
        public ChatAccessStatus AccessStatus { get; set; }
        public ChatAccessDTO(ChatAccess chatAccess)
        {
            this.User = new UserDTO(chatAccess.User);
            this.Chat = new ChatDTO(chatAccess.Chat);
            this.AccessStatus = chatAccess.ChatAccessStatus;
        }
    }
}
