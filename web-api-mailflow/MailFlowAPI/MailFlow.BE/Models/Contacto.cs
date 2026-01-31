using System;
using System.Collections.Generic;

namespace MailFlow.BE.Models;

public partial class Contacto
{
    public int ContactoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Creacion { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual ICollection<Lista> Lista { get; set; } = new List<Lista>();
}
