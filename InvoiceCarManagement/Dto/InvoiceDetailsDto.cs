using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Dto
{
    public class InvoiceDetailsDto
    {
        [Required]
        public int NationalID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
