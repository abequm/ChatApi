using Chat.Database.MsSql.Enums;

namespace Chat.Api.Domain.Chats
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ChatTypes ChatType { get; set; }
        public ChatDTO(Database.MsSql.Entities.Chat chat)
        {
            this.Title = chat.Title;
            this.ChatType = chat.ChatType;
            this.Id = chat.Id;
        }
    }
}
