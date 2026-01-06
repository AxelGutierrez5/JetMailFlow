using System;
using System.Collections.Generic;

namespace MailFlow.DAL;

public partial class Campania
{
    public int CamapaniaId { get; set; }

    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? FechaEnvio { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<CampaniaContacto> CampaniaContactos { get; set; } = new List<CampaniaContacto>();

    public virtual Usuario Usuario { get; set; } = null!;
}
