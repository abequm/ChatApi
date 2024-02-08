using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chat.Database.MsSql.Entities.Base;
using Chat.Database.MsSql.Enums;

namespace Chat.Database.MsSql.Entities
{
    public class ChatAccess : Entity
    {
        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ChatAccessStatus ChatAccessStatus { get; set; }
    }
}
