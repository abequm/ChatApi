using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chat.Database.MsSql.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public string IP { get; set; }
        public string Path { get; set; }
        public string RequestBody { get; set; }
        public DateTime Date { get; set; }
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
