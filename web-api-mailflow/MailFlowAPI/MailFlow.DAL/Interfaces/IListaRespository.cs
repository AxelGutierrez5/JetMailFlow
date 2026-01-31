
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MailFlow.BE.Models;

namespace MailFlow.DAL.Interfaces
{
    public interface IListaRespository : IGenericRepository<Lista>
    {

        Task<Lista?> GetWithContacts(Expression<Func<Lista, bool>> expression);
    }
}
