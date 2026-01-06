using System;
using System.Collections.Generic;

namespace MailFlow.DAL;

public partial class TemplateEmail
{
    public int TemplateId { get; set; }

    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Asunto { get; set; } = null!;

    public string ContenidoHtml { get; set; } = null!;

    public DateTime? Creacion { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
