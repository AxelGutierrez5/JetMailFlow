using System;
using System.Collections.Generic;

namespace MailFlow.BE.Models
    ;

public partial class Envio
{
    public int EnvioId { get; set; }

    public int CampaniaId { get; set; }

    public int ContactoId { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaEnvio { get; set; }

    public virtual Campania Campania { get; set; } = null!;

    public virtual Contacto Contacto { get; set; } = null!;
}
