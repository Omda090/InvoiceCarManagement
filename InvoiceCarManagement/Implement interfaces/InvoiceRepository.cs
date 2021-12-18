using AutoMapper;
using InvoiceCarManagement.Data;
using InvoiceCarManagement.Interfaces;
using InvoiceCarManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Implement_interfaces
{
    public class InvoiceRepository : InterfaceInvoice
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _Mapper;

        public InvoiceRepository(ApplicationDbContext context, IMapper Mapper)
        {
            _context = context;
            _Mapper = Mapper;
        }

        public async Task<List<InvoiceProduct>> GetAll()
        {
            return  _context.ToListAsync();
        }

        public async Task<InvoiceProduct> GetById(int Id)
        {
            return await  _context.InvoiceProductDto.FirstOrDefaultAsync(invoiceProduct => invoiceProduct.Id == ID);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
