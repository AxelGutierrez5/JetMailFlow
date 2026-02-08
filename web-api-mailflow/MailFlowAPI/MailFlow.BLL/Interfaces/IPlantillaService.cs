using MailFlow.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Interfaces
{
    public interface IPlantillaService
    {
        Task<PlantillaResponse> RegisterAsync(PlantillaRegistroRequest request);
        Task<IEnumerable<PlantillaResponse>> GetAllAsync();
        Task UpdateAsync(string id, PlantillaModificarRequest request);
        Task DeleteAsync(string id);
    }
}
