using Chat.Database.MsSql.Entities;

using Microsoft.EntityFrameworkCore;

namespace Chat.Database.MsSql.Context
{
    public class ChatContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Entities.Chat> Chats { get; set; }
        public virtual DbSet<ChatAccess> ChatAccesses { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
