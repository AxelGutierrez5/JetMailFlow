using MailFlow.DAL.Context;
using MailFlow.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.DAL.Respository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        protected DataContext _context;
        public GenericRepository(DataContext context)
        {

            _context = context;

        }

        public virtual async Task CreateAsync(TModel model)
        {
            await _context.Set<TModel>().AddAsync(model);
            await _context.SaveChangesAsync();

        }

        public virtual async Task DeleteAsync(TModel model)
        {
            _context.Set<TModel>().Remove(model);
            await _context.SaveChangesAsync();

        }

        public virtual async Task<IEnumerable<TModel>> FilterAsync(Expression<Func<TModel, bool>> expression)
        {
            return await _context.Set<TModel>().Where(expression).ToListAsync();
            
        }

        public virtual async Task<TModel?> GetAsync(Expression<Func<TModel, bool>> expression) 
        {
           
            return await _context.Set<TModel>().FirstOrDefaultAsync(expression);
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _context.Set<TModel>().ToListAsync();
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            _context.Set<TModel>().Update(model);
            await _context.SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
