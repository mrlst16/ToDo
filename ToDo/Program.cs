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
            var configuration = ConfigurationHelper.FromJsonFile();

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.RegisterContexts(configuration);
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.Run();
        }



    }
}