using System;
using System.Collections.Generic;

namespace MailFlow.DAL;

public partial class ListaContacto
{
    public int ListaId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Creacion { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}
