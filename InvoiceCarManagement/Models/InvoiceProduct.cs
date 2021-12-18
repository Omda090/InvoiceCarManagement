using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Models
{
    public class InvoiceProduct
    {
        public int ID { get; set; }
        public string CarName { get; set; }
        public long Model { get; set; }
        public decimal Price { get; set; }
        public int Quentity { get; set; }
        public string Desc { get; set; }
        public string Color { get; set; }


    }
}
