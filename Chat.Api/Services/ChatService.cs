using Chat.Api.Core.ExceptionsRequests;
using Chat.Api.Domain.ChatAccesses;
using Chat.Api.Domain.Chats;
using Chat.Api.Services.Interfaces;
using Chat.Database.MsSql.Context;
using Chat.Database.MsSql.Entities;
using Chat.Database.MsSql.Enums;

using Microsoft.EntityFrameworkCore;

namespace Chat.Api.Services
{
    public class ChatService : IChatService
    {
        public readonly ChatContext ChatContext;
        public ChatService(ChatContext chatContext)
        {
            this.ChatContext = chatContext;
        }
        public Task<List<ChatAccessDTO>> ChatApplications(Int32 chatId)
        {
            throw new NotImplementedException();
        }

        public Task<ChatDTO> CreateChat()
        {
            throw new NotImplementedException();
        }

        public async Task<ChatDTO> GetChat(Int32 chatId)
        {
            var chat = await ChatContext.Chats.FindAsync(chatId);
            if (chat is null)
            {
                throw new NotFoundException("Чат не найден", "Чата с таким идентификатором не существует");
            }
            return new ChatDTO(chat);
        }

        public async Task<List<ChatDTO>> UserChats(Int32 userId)
            => await ChatContext.Chats
            .Where(c => c.Accesses.Any(a => a.User.Id == userId && a.ChatAccessStatus != ChatAccessStatus.Pending))
            .Select(c => new ChatDTO(c)).ToListAsync();

        public async Task<List<ChatAccessDTO>> UserChatsPendings(Int32 userId)
        {
            var accesses = await ChatContext.ChatAccesses
                .Where(a => a.User.Id == userId && a.ChatAccessStatus == ChatAccessStatus.Pending)
                .Select(a => new ChatAccessDTO(a)).ToListAsync();
            return accesses;

        }
    }
}
