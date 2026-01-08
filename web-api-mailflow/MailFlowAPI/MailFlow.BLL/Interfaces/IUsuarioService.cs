using MailFlow.BLL.DTOs;
using MailFlow.UTILITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Interfaces
{
    public interface IUsuarioService
    {

        Task<LoginResult> VerifyCredentialsAsync(LoginRequest session);
        Task<UsuarioResponse> RegisterAsync(UsuarioRegistoRequest usuario);
    }

    
}
