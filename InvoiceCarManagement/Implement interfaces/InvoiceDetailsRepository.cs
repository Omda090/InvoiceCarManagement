using InvoiceCarManagement.Data;
using InvoiceCarManagement.Interfaces;
using InvoiceCarManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Implement_interfaces
{
    public class InvoiceDetailsRepository : BaseServiceRepository<InvoiceDetails>, InterfaceDetails
    {
        private readonly ApplicationDbContext _context;

        public InvoiceDetailsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
