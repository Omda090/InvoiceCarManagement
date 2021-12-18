using InvoiceCarManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<InvoiceProduct> invoiceProducts { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetailes { get; set; }

        
    }
}
