using Core.DTOs;
using FluentValidation;

namespace WebApi.Validation;

public class CreateValidation : AbstractValidator<CreateCustomerDTO>
{
    public CreateValidation()
    {
        RuleFor(x => x.FirstName).Length(3, 50);
        RuleFor(x => x.LastName).Length(3, 50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Phone).Length(10, 15).Matches(@"^\d+$");
        RuleFor(x => x.FechaDeNac).NotEmpty();
    }
}
