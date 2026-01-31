using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class ListaResponse
    {
        public int ListaId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Creacion { get; set; } = null!;

    }
}
