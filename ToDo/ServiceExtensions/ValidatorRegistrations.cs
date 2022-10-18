using FluentValidation;
using ToDo.Models.Requests;
using ToDo.Validators;

namespace ToDo.ServiceExtensions
{
    public static class ValidatorRegistrations
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            return services
                .AddTransient<IValidator<CreateListRequest>, CreateListRequestValidator>();
        }
    }
}
