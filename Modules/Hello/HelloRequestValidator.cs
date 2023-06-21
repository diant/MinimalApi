using FluentValidation;

namespace MinimalApi.Modules.Hello
{
    public class HelloRequestValidator : AbstractValidator<HelloRequest>
    {
        public HelloRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEqual("xxx")
                .WithMessage("This cannot be used as a name! Please try something else.")
                .WithSeverity(Severity.Error);
        }
    }
}
