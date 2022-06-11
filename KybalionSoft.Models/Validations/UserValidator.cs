using FluentValidation;
using KybalionSoft.Models.Segurity;

namespace KybalionSoft.Models.Validations
{
    public class UserValidator : AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("El nombre es requerido");

            RuleFor(x => x.LastName)
               .NotEmpty().WithMessage("El apellido es requerido");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El Email es requerido")
                .EmailAddress().WithMessage("Debe ingresar un email valido");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("El teléfono es requerido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El password es requerido")
                .MinimumLength(8).WithMessage("El password debe tener mínimo 8 caracteres");
        }
    }
}
