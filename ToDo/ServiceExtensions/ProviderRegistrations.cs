using ToDo.BLL;
using ToDo.Interfaces;

namespace ToDo.ServiceExtensions
{
    public static class ProviderRegistrations
    {
        public static IServiceCollection RegisterProviders(this IServiceCollection services)
        {
            return services
                .AddTransient<IToDoItemProvider, ToDoItemProvider>()
                .AddTransient<IToDoListProvider, ToDoListProvider>();
        }
    }
}
