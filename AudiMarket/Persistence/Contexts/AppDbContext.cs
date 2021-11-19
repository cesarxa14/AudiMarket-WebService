using AudiMarket.Domain.Models;
using AudiMarket.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace AudiMarket.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public DbSet<MusicProducer> MusicProducers { get; set; }

        public DbSet<Publication> Publications { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
            //_configuration = configuration;

        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
        }
        */

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Constraints
            

            //Music Producer
            builder.Entity<MusicProducer>().ToTable("MusicProducer");
            builder.Entity<MusicProducer>().HasKey(p => p.Id);
            builder.Entity<MusicProducer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MusicProducer>().Property(p => p.Firstname).IsRequired().HasMaxLength(50);
            builder.Entity<MusicProducer>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<MusicProducer>().Property(p => p.Dni).IsRequired().HasMaxLength(7);
            builder.Entity<MusicProducer>().Property(p => p.Entrydate).IsRequired();
            builder.Entity<MusicProducer>().Property(p => p.User).IsRequired().HasMaxLength(15);
            builder.Entity<MusicProducer>().Property(p => p.Password).IsRequired().HasMaxLength(15);

            
            //Publication
            builder.Entity<Publication>().ToTable("Publication");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Publication>().Property(p => p.PublicationDate).IsRequired();
            





            //RelationShips
            //builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<MusicProducer>().HasMany(p => p.Publications).WithOne(p => p.MusicProducer).HasForeignKey(p => p.MusicProducerId);

            // Seed Data
           

            // Music Producer

            builder.Entity<MusicProducer>().HasData
                (
                    new MusicProducer { Id = 1, Firstname = "Cesar", Lastname = "Torres", Dni = "72289050", User = "cesarxa14", Password = "1234" }
                );

            //Publications

            builder.Entity<Publication>().HasData
                (
                    new Publication { Id = 1, Description = "Soy experto en electronica", PublicationDate = DateTime.Now, MusicProducerId = 1}
                );



            //Constraints
           

            builder.UseSnakeCaseNamingConventions();
        }
    }
}
