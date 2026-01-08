using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class UsuarioResponse
    {
        public int UsuarioId { get; set; }

        public string NombreCompleto { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Creacion { get; set; } = null!;

    }
}
