using MailFlow.BE.Models;
using MailFlow.DAL.Context;
using MailFlow.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.DAL.Respository
{
    public class PlantillaRepository : GenericRepository<Plantilla>, IPlantillaRepository
    {
        public PlantillaRepository(DataContext context) : base(context)
        {
        }

        public async Task<int> HasReferenceAsync(string id)
        {
            try
            {
                var plantillaId = int.Parse(id);
                var count = await _context.Campania.CountAsync(c => c.PlantillaId == plantillaId);
                return count;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
