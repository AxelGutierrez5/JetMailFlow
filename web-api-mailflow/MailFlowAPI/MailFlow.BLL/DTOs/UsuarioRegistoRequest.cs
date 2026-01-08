using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class UsuarioRegistoRequest
    {
        public string NombreCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
