using AudiMarket.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


//5555555
namespace AudiMarket.Shared.Persistence.Contexts
{
    public class AppDbContext2 : DbContext
    {
        public DbSet<MusicProducer> MusicProducers { get; set; }
        protected readonly IConfiguration _configuration;

        public AppDbContext2(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Music producer
            builder.Entity<MusicProducer>().ToTable("MusicProducer");
            builder.Entity<MusicProducer>().HasKey(p => p.Id);
            builder.Entity<MusicProducer>().Property(p => p.Firstname).IsRequired();
            builder.Entity<MusicProducer>().Property(p => p.Lastname).IsRequired();
            builder.Entity<MusicProducer>().Property(p => p.Dni).IsRequired();
            builder.Entity<MusicProducer>().Property(p => p.Entrydate).IsRequired();
            builder.Entity<MusicProducer>().Property(p => p.User).IsRequired();
            builder.Entity<MusicProducer>().Property(p => p.Password).IsRequired();
        }
    }
}
