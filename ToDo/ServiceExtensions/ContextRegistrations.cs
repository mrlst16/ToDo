using Common.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using ToDo.DAL.EntityFramework;

namespace ToDo.ServiceExtensions
{
    public static class ContextRegistrations
    {
        public static IServiceCollection RegisterContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("todo");
            services.AddDbContext<ToDoContext>(o =>
            {
                o.EnableDetailedErrors(true);
                o.UseSqlServer(connectionString);
            });
            services.AddTransient(typeof(ISRDRepository<,>), typeof(ToDoRepository<,>));
            return services;
        }
    }
}
