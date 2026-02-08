using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class PlantillaRegistroRequest
    {
        public int UsuarioId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Asunto { get; set; } = null!;

        public string ContenidoHtml { get; set; } = null!;

    }
}
