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
  
        public DbSet<Project> Projects { get; set; }

  
        public DbSet<VideoProducer> VideoProducers { get; set; }

        public DbSet<Publication> Publications { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<PlayList> PlayLists { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<PayMethod> PayMethods  { get; set; }




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

            builder.Entity<PayMethod>().ToTable("PayMethod");
            builder.Entity<PayMethod>().HasKey(p => p.IdPayMethod);
            // Constraints
            

            //Music Producer
            builder.Entity<MusicProducer>().ToTable("MusicProducer");
            builder.Entity<MusicProducer>().HasKey(p => p.Id);
            builder.Entity<MusicProducer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MusicProducer>().Property(p => p.Firstname).IsRequired().HasMaxLength(50);
            builder.Entity<MusicProducer>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<MusicProducer>().Property(p => p.Dni).IsRequired().HasMaxLength(8);
            builder.Entity<MusicProducer>().Property(p => p.Entrydate).IsRequired();
            builder.Entity<MusicProducer>().Property(p => p.User).IsRequired().HasMaxLength(15);
            builder.Entity<MusicProducer>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            
            //Video Producer
            builder.Entity<VideoProducer>().ToTable("MusicProducer");
            builder.Entity<VideoProducer>().HasKey(p => p.Id);
            builder.Entity<VideoProducer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<VideoProducer>().Property(p => p.Firstname).IsRequired().HasMaxLength(50);
            builder.Entity<VideoProducer>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<VideoProducer>().Property(p => p.Dni).IsRequired().HasMaxLength(8);
            builder.Entity<VideoProducer>().Property(p => p.Entrydate).IsRequired();
            builder.Entity<VideoProducer>().Property(p => p.User).IsRequired().HasMaxLength(15);
            builder.Entity<VideoProducer>().Property(p => p.Password).IsRequired().HasMaxLength(15);

            
            //Publication
            builder.Entity<Publication>().ToTable("Publication");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Publication>().Property(p => p.PublicationDate).IsRequired();
            
            //Review
            builder.Entity<Review>().ToTable("Review");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.Qualification).IsRequired();
            builder.Entity<Review>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Review>().Property(p => p.ReviewDate).IsRequired();

            //Voucher
            builder.Entity<Voucher>().ToTable("Voucher");
            builder.Entity<Voucher>().HasKey(p => p.Id);
            builder.Entity<Voucher>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Voucher>().Property(p => p.IdPaymethod).IsRequired();
            builder.Entity<Voucher>().Property(p => p.ContractId).IsRequired();
            
            //Play List
            builder.Entity<PlayList>().ToTable("PlayList");
            builder.Entity<PlayList>().HasKey(p => p.Id);
            builder.Entity<PlayList>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PlayList>().Property(p => p.Description).IsRequired();
            builder.Entity<PlayList>().Property(p => p.AddedDate).IsRequired();
            builder.Entity<PlayList>().Property(p => p.MusicProducerId).IsRequired();
            
            //Projects
            builder.Entity<Project>().ToTable("PlayList");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Project>().Property(p => p.Description).IsRequired();
            builder.Entity<Project>().Property(p => p.AddedDate).IsRequired();
            builder.Entity<Project>().Property(p => p.Name).IsRequired();
            builder.Entity<Project>().Property(p => p.PlayListId).IsRequired();


            //RelationShips
            //builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<MusicProducer>().HasMany(p => p.Publications).WithOne(p => p.MusicProducer).HasForeignKey(p => p.MusicProducerId);
            builder.Entity<MusicProducer>().HasMany(p => p.Reviews).WithOne(p => p.MusicProducer).HasForeignKey(p => p.MusicProducerId);

            // Seed Data
           

            // Music Producer

            builder.Entity<MusicProducer>().HasData
                (
                    new MusicProducer { Id = 1, Firstname = "Cesar", Lastname = "Torres", Dni = "72289050", User = "cesarxa14", Password = "1234" }
                );
            
            // Video Producer

            builder.Entity<VideoProducer>().HasData
            (
                new VideoProducer { Id = 1, Firstname = "Jorge", Lastname = "Tafur", Dni = "74582556", User = "jorgetafur", Password = "asdfg" }
            );

            //Publications

            builder.Entity<Publication>().HasData
                (
                    new Publication { Id = 1, Description = "Soy experto en electronica", PublicationDate = DateTime.Now, MusicProducerId = 1}
                );
            
            //Reviews

            builder.Entity<Review>().HasData
            (
                new Review { Id = 1, Qualification = 4.5, Description = "Hizo buen trabajo", ReviewDate = DateTime.Now, MusicProducerId = 1, VideoProducerId = 1}
            );

            //Voucher

            builder.Entity<Voucher>().HasData
            (
                new Voucher { Id = 1, IdPaymethod = 1,ContractId = 1}
            );
            
            //Play List

            builder.Entity<PlayList>().HasData
            (
                new PlayList { Id = 1, MusicProducerId = 1, Description = "buenas rolas", AddedDate = DateTime.Now}
            );
            
            //Pay method

            builder.Entity<PayMethod>().HasData
            (
                new PayMethod { IdPayMethod = 1, Description = "metodo de pago blablabla", Name = "pos visa"}
            );
            
            //Project

            builder.Entity<Project>().HasData
            (
                new Project { Id = 1, Description = "metodo de pago blablabla", Name = "pos visa", AddedDate = DateTime.Now, PlayListId = 1}
            );

            //Constraints
           

            builder.UseSnakeCaseNamingConventions();
        }
    }
}
