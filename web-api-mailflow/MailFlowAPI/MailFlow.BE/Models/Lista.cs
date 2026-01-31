using System;
using System.Collections.Generic;

namespace MailFlow.BE.Models;

public partial class Lista
{
    public int ListaId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Creacion { get; set; }

    public virtual ICollection<Campania> Campania { get; set; } = new List<Campania>();

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}
