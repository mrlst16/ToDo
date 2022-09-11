using Common.AspDotNet.Handlers;
using Common.Helpers;
using Common.Interfaces.Repository;
using ToDo.DAL.EntityFramework;
using ToDo.ServiceExtensions;

namespace ToDo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = ConfigurationHelper.FromJsonFiles();

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services
                .RegisterContexts(configuration)
                .RegisterLoaders()
                .RegisterValidators()
                .RegisterProviders();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                ErrorHandlingMiddleware errorHandler = new ErrorHandlingMiddleware();
                await errorHandler.Handle(context, next);
            });

            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.Run();
        }



    }
}