using System;
using System.Collections.Generic;

namespace MailFlow.BE.Models;

public partial class Plantilla
{
    public int PlantillaId { get; set; }

    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Asunto { get; set; } = null!;

    public string ContenidoHtml { get; set; } = null!;

    public DateTime Creacion { get; set; }

    public virtual ICollection<Campania> Campania { get; set; } = new List<Campania>();

    public virtual Usuario Usuario { get; set; } = null!;
}
