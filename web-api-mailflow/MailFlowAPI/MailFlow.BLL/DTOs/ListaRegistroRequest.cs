using MailFlow.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class ListaRegistroRequest
    {
        public string Nombre { get; set; } = null!;
        public ICollection<int> Contactos { get; set; } = null!;
    }
}
