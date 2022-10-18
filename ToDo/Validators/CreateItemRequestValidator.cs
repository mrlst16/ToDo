using FluentValidation;
using ToDo.Models.Requests;

namespace ToDo.Validators
{
    public class CreateItemRequestValidator : AbstractValidator<CreateItemRequest>
    {
        public CreateItemRequestValidator()
        {
            RuleFor(x => x.Label)
                .NotEmpty()
                .NotNull()
                .WithMessage("Label can not be null or empty");

            RuleFor(x => x.ListId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("ListId may not be null or empty, and must be greater than 0");
        }
    }
}
