using InvoiceCarManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Interfaces
{
   public interface IBaseService<T> where T : class
    {

        Task<T> GetById(int Id);
        Task<List<T>> GetAll();
        Task<bool> SaveChanges();
        void Remove(T entity);
        void Add(T entity, InvoiceDetails invoiceDetails);
    }
    }
