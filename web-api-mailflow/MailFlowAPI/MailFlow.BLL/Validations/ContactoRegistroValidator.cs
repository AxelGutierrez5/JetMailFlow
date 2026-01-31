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
    public class ContactoRegistroValidator : AbstractValidator<ContactoRegistroRequest>
    {

        public ContactoRegistroValidator(IContactoRepository contactoRepository) {

            base.ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress()
                .WithMessage("El email tiene el formato incorrecto")
                .MustAsync(async (email,CancellationToken) => !(await contactoRepository.GetAsync(x=> x.Email == email) != null));

            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido es obligatorio");
            RuleFor(x => x.Estado).NotEmpty().WithMessage("El estado es obligatorio");
            
            

        
        }
    }
}
