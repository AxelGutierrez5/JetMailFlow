using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MailFlow.BE.Models;
using MailFlow.BLL.DTOs;

namespace MailFlow.BLL.Validations
{
    public class PlantillaRegistroValidator : AbstractValidator<PlantillaRegistroRequest>
    {
        public PlantillaRegistroValidator()
        {
            RuleFor(x=> x.Asunto).NotEmpty().WithMessage("El asunto no puede estar vacío.")
                .MaximumLength(150).WithMessage("El asunto no puede exceder los 150 caracteres.");

            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre no puede estar vacío.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");
            RuleFor(x => x.ContenidoHtml).NotEmpty().WithMessage("El contenido HTML no puede estar vacío.");

        }
    }
}
