using InvoiceCarManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Dto
{
    public class InvoiceProductDto
    {
        //public int ID { get; set; }
        [Required]
        public string CarName { get; set; }
        public long Model { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Quentity { get; set; }
        public string Desc { get; set; }
        public string Color { get; set; }
        public ICollection<InvoiceDetailsDto>  InvoiceDetails{ get; set; }
    } 
}
