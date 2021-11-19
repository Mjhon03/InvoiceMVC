using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.Entities
{
    public class Invoice
    {
        public int ID { set; get; } 
        public int Id_client { set; get; }
        public int Cod { set; get; }

        public List<Invoices_detail> details { set; get; }
    }
}
