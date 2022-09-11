using FluentValidation;
using ToDo.Interfaces;
using ToDo.Models.Requests;

namespace ToDo.Validators
{
    public class CreateListRequestValidator : AbstractValidator<CreateListRequest>
    {
        public CreateListRequestValidator(
            IToDoListLoader loader
            )
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1)
                .WithMessage("Invalid User Id");

            RuleFor(x => x.Label)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lable may not be null or empty");

            RuleFor(x => x)
                .MustAsync(async (x, c) => 
                    await LabelBeAvailable(loader, x.UserId, x.Label));

        }

        private async Task<bool> LabelBeAvailable(IToDoListLoader loader, int userid, string label)
        {
            var lists = await loader.GetAllListsForUser(userid);
            var labels = lists.Select(x => x.Label);
            return !labels.Contains(label);
        }
    }
}
