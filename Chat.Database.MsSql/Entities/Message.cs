using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chat.Database.MsSql.Entities.Base;

namespace Chat.Database.MsSql.Entities
{
    public class Message : Entity
    {
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }
        public string Content { get; set; }
        public virtual IEnumerable<User> ViewedUsers { get; set; }
    }
}
