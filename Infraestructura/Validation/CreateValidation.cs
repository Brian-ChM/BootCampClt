using Core.DTOs.Customer;
using FluentValidation;

namespace Infraestructura.Validation;

public class CreateValidation : AbstractValidator<CreateCustomerDTO>
{
    public CreateValidation()
    {
        RuleFor(x => x.FirstName).Length(3, 50);
        RuleFor(x => x.LastName).Length(3, 50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Phone).Length(10, 15).Matches(@"^\d+$")
            .WithMessage("El teléfono solo debe contener dígitos.");
        RuleFor(x => x.FechaDeNac).NotEmpty();
    }
}
