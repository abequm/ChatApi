using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Chat.Database.MsSql.Entities.Base;
using Chat.Database.MsSql.Enums;

namespace Chat.Database.MsSql.Entities
{
    public class Chat : Entity
    {
        public string Title { get; set; }
        public ChatTypes ChatType { get; set; }
        public virtual List<ChatAccess> Accesses { get; set; }
    }
}
