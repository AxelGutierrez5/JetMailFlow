using System;
using System.Collections.Generic;

namespace MailFlow.BE.Models
    ;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Creacion { get; set; }

    public string Rol { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Campania> Campania { get; set; } = new List<Campania>();

    public virtual ICollection<Plantilla> Plantillas { get; set; } = new List<Plantilla>();
}
