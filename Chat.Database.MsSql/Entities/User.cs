using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chat.Database.MsSql.Entities.Base;

namespace Chat.Database.MsSql.Entities
{
    public class User : Entity
    {
        [Key]
        public string Nick { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual List<ChatAccess> ChatAccesses { get; set; }
        //public virtual IQueryable<ChatAccess> ChatAccesses { get; set; }
    }
}
