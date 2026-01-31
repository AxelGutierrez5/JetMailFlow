using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class CampaniaRegistroRequest
    {
        public int UsuarioId { get; set; }
        public int PlantillaId { get; set; }
        public int ListaId { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaProgramada { get; set; }


    }
}
