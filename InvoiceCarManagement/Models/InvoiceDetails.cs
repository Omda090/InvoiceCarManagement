using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Models
{
    public class InvoiceDetails
    {
        public int ID { get; set; }
        public int NationalID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int InvoiceProductId { get; set; }
        public virtual InvoiceProduct InvoiceProduct  { get; set; }

    }
}
