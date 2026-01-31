using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using MailFlow.BLL.DTOs;
using MailFlow.DAL.Interfaces;


namespace MailFlow.BLL.Validations
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {

        public LoginValidator(IUsuarioRepository usuarioRepository)
        {
            base.ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("Formato de email incorrecto");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseñá es obligatorio");


        }
    }
}
