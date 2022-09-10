using Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDo.Models;
using ToDo.Models.Users;

namespace ToDo.DAL.EntityFramework
{
    public class ToDoContext : DbContext
    {

        private IConfiguration _configuration;

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> Lists { get; set; }
        public DbSet<ToDoItem> Items { get; set; }
        public DbSet<ToDoListStatus> Status { get; set; }

        public ToDoContext()
        {
            _configuration = ConfigurationHelper.FromJsonFile();
        }

        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
            _configuration = ConfigurationHelper.FromJsonFile();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("todo");
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.Id);
                entityTypeBuilder.HasMany(x => x.Lists)
                    .WithOne()
                    .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<ToDoList>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.Id);
                entityTypeBuilder.HasMany(x => x.Items)
                    .WithOne()
                    .HasForeignKey(x => x.ToDoListId);
                entityTypeBuilder.HasIndex(x => new
                    {
                        x.Label,
                        x.UserId
                    })
                    .IsUnique();
            });

            modelBuilder.Entity<ToDoListStatus>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.Id);

                //Populate the static data set
                entityTypeBuilder.HasData(
                    new ToDoListStatus() { Id = 1, Name = "Backlog" },
                    new ToDoListStatus() { Id = 2, Name = "InProgress" },
                    new ToDoListStatus() { Id = 3, Name = "OnHold" },
                    new ToDoListStatus() { Id = 4, Name = "Completed" }
                );
            });

            modelBuilder.Entity<ToDoItem>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.Id);
            });
        }
    }
}
