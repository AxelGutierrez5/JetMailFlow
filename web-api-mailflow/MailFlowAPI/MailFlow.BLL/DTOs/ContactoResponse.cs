using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class ContactoResponse
    {
        public int ContactoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Creacion { get; set; } = string.Empty!;
        public string Estado { get; set; } = null!;

    }
}
