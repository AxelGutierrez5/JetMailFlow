using System;
using System.Collections.Generic;

namespace MailFlow.DAL;

public partial class CampaniaContacto
{
    public int CampaniaId { get; set; }

    public int ContactoId { get; set; }

    public string? Estado { get; set; }

    public virtual Campania Campania { get; set; } = null!;

    public virtual Contacto Contacto { get; set; } = null!;
}
