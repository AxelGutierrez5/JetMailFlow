using MailFlow.BE.Models;
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
    public class CampaniaRepository : GenericRepository<Campania>, ICampaniaRepository
    {
        public CampaniaRepository(DataContext context) : base(context)
        {
        }

        public async Task<Campania?> GetWithAssociations(Expression<Func<Campania, bool>> expression)
        {
            try
            {
                return await _context.Campania
                    .Include(campania => campania.Plantilla)
                    .Include(campania => campania.Usuario).FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
