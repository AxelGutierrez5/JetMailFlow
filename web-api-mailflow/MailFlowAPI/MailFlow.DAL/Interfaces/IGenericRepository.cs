using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.DAL.Interfaces
{
    public interface IGenericRepository<TModel> where TModel : class
    {

        Task CreateAsync(TModel model);

        Task DeleteAsync(TModel model);

        Task<IEnumerable<TModel>> GetAllAsync();

        Task<IEnumerable<TModel>> FilterAsync(Expression<Func<TModel,bool>> expression);

        Task<TModel?> GetAsync(Expression<Func<TModel, bool>> expression);

        Task UpdateAsync(TModel model);

        Task SaveChangesAsync();

    }
}
