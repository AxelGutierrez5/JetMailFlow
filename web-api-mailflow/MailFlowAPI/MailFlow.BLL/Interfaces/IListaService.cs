using MailFlow.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Interfaces
{
    public interface IListaService
    {

        Task<IEnumerable<ListaResponse>> GetAllAsync();
        Task<ListaResponse> CreateAsync(ListaRegistroRequest request);
        Task ModifyNameAsync(string id, string name);
        Task DeleteAsync(string id);


    }
}
