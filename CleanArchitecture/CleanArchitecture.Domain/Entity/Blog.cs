using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entity
{
    public class Blog
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? auther { get; set; }
        public string? url { get; set; }
    }
}
