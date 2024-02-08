using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chat.Database.MsSql.Entities.Base;

namespace Chat.Database.MsSql.Enums
{
    public enum ChatAccessStatus
    {
        Pending,
        Guest,  // readonly
        Participant, // read-write
        Moderator, // cant delete chat
        Admin // full access
    }
}
