using FluentValidation;
using KybalionSoft.Models.Segurity;

namespace KybalionSoft.Models.Validations
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El Email es requerido")
                .EmailAddress().WithMessage("Debe ser un Email valido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El Password es requerido");
        }
    }
}
