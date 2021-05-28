using FluentValidation;

namespace Builders.Application.Palidrome.Queries
{
    public class CheckPalindromeQueryValidator : AbstractValidator<CheckPalindromeQuery>
    {
        public CheckPalindromeQueryValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Value cannot be empty");
        }
    }
}
