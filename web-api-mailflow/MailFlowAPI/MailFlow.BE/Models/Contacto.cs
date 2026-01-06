using System;
using System.Collections.Generic;

namespace MailFlow.DAL;

public partial class Contacto
{
    public int ContactotId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Creacion { get; set; }

    public virtual ICollection<CampaniaContacto> CampaniaContactos { get; set; } = new List<CampaniaContacto>();

    public virtual ICollection<ListaContacto> Lista { get; set; } = new List<ListaContacto>();
}
