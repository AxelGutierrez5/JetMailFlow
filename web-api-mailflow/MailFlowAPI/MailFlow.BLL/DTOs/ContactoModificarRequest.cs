using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class ContactoModificarRequest
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

    }
}
