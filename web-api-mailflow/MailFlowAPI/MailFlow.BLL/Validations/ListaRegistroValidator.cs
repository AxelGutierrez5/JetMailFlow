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
    public class ListaRegistroValidator : AbstractValidator<ListaRegistroRequest>
    {

        public ListaRegistroValidator(IListaRespository listaRespository)
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MustAsync(async(nombre, cancelToken)=> !(await listaRespository.GetAsync(x=> x.Nombre == nombre) != null))
                .WithMessage("Ya existe ese nombre");
            RuleFor(x => x.Contactos)
                .NotNull().WithMessage("La lista debe existir")
                .Must(lista => lista.Count() > 0).WithMessage("La lista debe tener al menos un contacto");

        }
    }
}
