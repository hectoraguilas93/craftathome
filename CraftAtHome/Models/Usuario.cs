using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftAtHome.Models
{
    public class Usuario
    {
        public Guid id { get; set; }
        public String name { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String password { get; set; }

    }
}
