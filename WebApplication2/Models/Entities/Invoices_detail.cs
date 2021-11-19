using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.Entities
{
    public class Invoices_detail
    {
        public int ID { set; get; }
        public int id_Invoice { set; get; }
        public string Description { set; get; }
        public int Value { set; get; }
        public int Client_id { set; get; }
    }
}
