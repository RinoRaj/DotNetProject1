using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyModel;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace MyContactManagerData
{
    public class MyContactManagerDbContext :DbContext
    {
        private static IConfigurationRoot _configuration;

        public DbSet<State> States  { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public MyContactManagerDbContext()
        {
           // 
        }

        public MyContactManagerDbContext(DbContextOptions options) : base(options)
        {
            //
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",optional:true, reloadOnChange : true);
            _configuration = builder.Build();
            var ConnectionString = _configuration.GetConnectionString("MyContactManager");
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(x=>
            {
                x.HasData(
                    new State() { id = 1, Name = "Alabama", Abbreviation = "AL"},
                    new State() { id = 2, Name = "Alaska", Abbreviation = "AK" },
                    new State() { id = 3, Name = "Arizona", Abbreviation = "AZ" }
                );
            });
        }

    }
}