using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHttp_ErrorHandling_Api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime creation_data { get; set; }
        public string description { get; set; }
    }
}
