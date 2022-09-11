using ToDo.BLL;
using ToDo.Interfaces;

namespace ToDo.ServiceExtensions
{
    public static class LoaderRegistrations
    {
        public static IServiceCollection RegisterLoaders(this IServiceCollection services)
        {
            return services
                    .AddTransient<IToDoItemLoader, ToDoItemLoader>()
                    .AddTransient<IToDoListLoader, ToDoListLoader>();
        }
    }
}
