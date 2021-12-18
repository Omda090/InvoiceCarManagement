using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Dto
{
    public class InvoiceProductDto
    {
        public string CarName { get; set; }
        public long Model { get; set; }
        public decimal Price { get; set; }
        public int Quentity { get; set; }
    }
}
