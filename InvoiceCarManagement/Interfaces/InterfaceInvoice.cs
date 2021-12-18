using InvoiceCarManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Interfaces
{
   public interface InterfaceInvoice
    {

        Task<InvoiceProduct> GetById(int Id);
        Task<List<InvoiceProduct>> GetAll();
        Task<bool> SaveChanges();


        }
    }
