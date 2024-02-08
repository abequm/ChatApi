using Chat.Api.Domain.ChatAccesses;
using Chat.Api.Domain.Chats;

namespace Chat.Api.Services.Interfaces
{
    public interface IChatService
    {
        Task<ChatDTO> CreateChat();
        Task<List<ChatDTO>> UserChats(int userId);
        Task<List<ChatAccessDTO>> ChatApplications(int chatId);
        Task<List<ChatAccessDTO>> UserChatsPendings(int userId);
        Task<ChatDTO> GetChat(int chatId);
    }
}
