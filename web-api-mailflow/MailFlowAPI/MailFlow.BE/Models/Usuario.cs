using System;
using System.Collections.Generic;

namespace MailFlow.DAL;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Creacion { get; set; } = null!;

    public virtual ICollection<Campania> Campania { get; set; } = new List<Campania>();

    public virtual ICollection<TemplateEmail> TemplateEmails { get; set; } = new List<TemplateEmail>();
}
