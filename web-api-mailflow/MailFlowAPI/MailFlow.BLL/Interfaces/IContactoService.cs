using MailFlow.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Interfaces
{
    public interface IContactoService
    {
        Task<ContactoResponse> RegisterAsync(ContactoRegistroRequest request);
        Task UpdateAsync(ContactoModificarRequest request, string id);
        Task DeleteAsync(string id);
        Task ImportCSVAsync();
        Task<IEnumerable<ContactoResponse>> GetAllAsync();
        Task<IEnumerable<ContactoResponse>> FilterAsync(string discrim);

    }
}
