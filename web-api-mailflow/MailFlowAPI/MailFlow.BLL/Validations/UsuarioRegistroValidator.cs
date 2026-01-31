using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MailFlow.BLL.DTOs;
using MailFlow.DAL.Interfaces;

namespace MailFlow.BLL.Validations
{
    public class UsuarioRegistroValidator : AbstractValidator<UsuarioRegistoRequest>
    {
        public UsuarioRegistroValidator(IUsuarioRepository repository)
        {
            base.ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.NombreCompleto).NotEmpty().WithMessage("El nombre completo es obligatorio");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("Formato de email incorrecto")
                .MustAsync(async (email, CancellationToken) => !(await repository.GetAsync(x => x.Email == email) != null)).WithMessage("El correo ya esta registrado");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseñá es obligatorio")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$")
                .WithMessage("La contraseña debe tener mínimo 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial");

        }
    }
}
