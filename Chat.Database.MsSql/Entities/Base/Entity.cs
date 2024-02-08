using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Chat.Database.MsSql.Entities.Base
{
    [PrimaryKey("Id")]
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; }
        public Entity() => Init();
        private void Init()
        {
            this.CreatedAt = DateTime.Now;
            this.Active = true;
        }
        public void Update()
        {
            this.UpdatedAt = DateTime.Now;
        }
    }
}
