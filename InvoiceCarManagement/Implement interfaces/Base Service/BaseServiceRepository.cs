using AutoMapper;
using InvoiceCarManagement.Data;
using InvoiceCarManagement.Interfaces;
using InvoiceCarManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceCarManagement.Implement_interfaces
{
    public class BaseServiceRepository<T> : IBaseService<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

       

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

       
    }
}
