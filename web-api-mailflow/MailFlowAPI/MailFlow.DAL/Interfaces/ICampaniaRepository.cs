using MailFlow.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.DAL.Interfaces
{
    public interface ICampaniaRepository: IGenericRepository<Campania>
    {
        Task<Campania?> GetWithAssociations(Expression<Func<Campania, bool>> expression);
    }
}
