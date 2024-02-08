using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Database.MsSql.Enums
{
    public enum ChatTypes
    {
        Personal, // Личный чат
        Public,   // Общедоступный чат
        Private,  // Закрытый чат
        Chanel,   // Канал
        Favorite  // Избранное/сохраненные сообщения
    }
}
