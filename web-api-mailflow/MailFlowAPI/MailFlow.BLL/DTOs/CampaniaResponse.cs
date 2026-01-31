using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class CampaniaResponse
    {
        public string Nombre { get; set; } = null!;

        public DateTime FechaProgramada { get; set; }

        public string Estado { get; set; } = null!;
    }
}
