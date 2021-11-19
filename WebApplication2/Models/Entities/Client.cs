using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.Entities
{
    public class Client
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Last_name { set; get; }
        public string Document_id { set; get; }
    }
}
