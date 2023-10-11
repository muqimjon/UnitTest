using FluentValidation;
using UnitTest.Service.DTOs.Users;

namespace UT.Service.Validators;

public class UserCreationDtoValidator : AbstractValidator<UserCreationalDto>
{
    public UserCreationDtoValidator()
    {
        RuleFor(x => x.PhoneNumber).NotNull()
            .NotEmpty()
            .Length(8)
            .Must(p => p.Substring(0, 4).Equals("+998"));

        RuleFor(x => x.Email).NotNull()
            .NotEmpty()
            .MinimumLength(8)
            .EmailAddress();

        RuleFor(x => x.Password).NotNull()
            .NotEmpty()
            .MinimumLength(6)
            .Must(p => p.Any(i => "~`! @#$%^&*()_-+={[}]|\\:;\"'<,>.?/".Contains(i)))
            .Must(p => p.Any(i => char.IsDigit(i)))
            .Must(p => p.Any(i => char.IsUpper(i)))
            .Must(p => p.Any(i => char.IsLower(i)));

        RuleFor(u => u.FirstName).NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(15)
            .Must(p => p.All(i => char.IsLetter(i)));

        RuleFor(u => u.LastName).NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(15)
            .Must(p => p.All(i => char.IsLetter(i)));
    }
}