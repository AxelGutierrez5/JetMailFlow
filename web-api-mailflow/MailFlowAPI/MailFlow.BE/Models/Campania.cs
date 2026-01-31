

using System;
using System.Collections.Generic;

namespace MailFlow.BE.Models;

public partial class Campania
{
    public int CampaniaId { get; set; }

    public int UsuarioId { get; set; }

    public int PlantillaId { get; set; }

    public int ListaId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaProgramada { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime Creacion { get; set; }


    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual Lista Lista { get; set; } = null!;

    public virtual Plantilla Plantilla { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
