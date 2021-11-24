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


        public DbSet<Contracts> Contracts { get; set; }
        
        public DbSet<Message> Message { get; set; }
        
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
        }*/
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PayMethod>().ToTable("PayMethod");
            builder.Entity<PayMethod>().HasKey(p => p.IdPayMethod);
            // Constraints
            

            //Music Producer
            builder.Entity<MusicProducer>().ToTable("MusicProducer");
            builder.Entity<MusicProducer>().HasKey(p => p.Id);

           // builder.Entity<MusicProducer>().HasMany(p => p.Reviews).WithOne(p => p.MusicProducer).HasForeignKey(p => p.MusicProducerId);

            builder.Entity<MusicProducer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<MusicProducer>().Property(p => p.Firstname).IsRequired().HasMaxLength(50);
            builder.Entity<MusicProducer>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<MusicProducer>().Property(p => p.Dni).IsRequired().HasMaxLength(8);
            builder.Entity<MusicProducer>().Property(p => p.Entrydate).IsRequired();
            builder.Entity<MusicProducer>().Property(p => p.User).IsRequired().HasMaxLength(15);
            builder.Entity<MusicProducer>().Property(p => p.Password).IsRequired().HasMaxLength(15);
            
            //Video Producer
            builder.Entity<VideoProducer>().ToTable("VideoProducer");
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

            builder.Entity<Voucher>().Property(p => p.PayMethodId).IsRequired();

            builder.Entity<Voucher>().Property(p => p.ContractId).IsRequired();
            
            //Play List
            builder.Entity<PlayList>().ToTable("PlayList");
            builder.Entity<PlayList>().HasKey(p => p.Id);
            builder.Entity<PlayList>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PlayList>().Property(p => p.Description).IsRequired();
            builder.Entity<PlayList>().Property(p => p.AddedDate).IsRequired();
            builder.Entity<PlayList>().Property(p => p.MusicProducerId).IsRequired();
            
            //Projects
            builder.Entity<Project>().ToTable("Project");
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
                    new MusicProducer { Id = 1, Firstname = "Cesar", Lastname = "Torres", Dni = "72243434", User = "cesarxa14", Password = "1234" },
                    new MusicProducer { Id = 2, Firstname = "Kevin", Lastname = "Gonzales", Dni = "72289656", User = "kevin10", Password = "4321" }
                );
            
            // Video Producer

            builder.Entity<VideoProducer>().HasData
            (
                new VideoProducer { Id = 1, Firstname = "Jorge", Lastname = "Tafur", Dni = "74582556", User = "jorgetafur", Password = "asdfg" }
            );

            //Publications

            builder.Entity<Publication>().HasData
                (
                    new Publication { Id = 1, Description = "Soy experto en electronica", PublicationDate = DateTime.Now, MusicProducerId = 1},
                    new Publication { Id = 2, Description = "Soy experto en musica clasica", PublicationDate = DateTime.Now, MusicProducerId = 1 },
                    new Publication { Id = 3, Description = "Soy experto en techno", PublicationDate = DateTime.Now, MusicProducerId = 2 }
                );
            
            //Reviews

            builder.Entity<Review>().HasData
            (
                new Review { Id = 1, Qualification = 4.5, Description = "Hizo buen trabajo", ReviewDate = DateTime.Now, MusicProducerId = 1, VideoProducerId = 1}
            );

            //Contracts

            builder.Entity<Contracts>().HasData(
                new Contracts {Id = 1, MusicProducerId = 2, VideoProducerId = 1, Content = "Contrato para noviembre" }
               );

            //Voucher

            builder.Entity<Voucher>().HasData
            (

                new Voucher { Id = 1, PayMethodId = 1,ContractId = 1}

            );
            
            //Play List

            builder.Entity<PlayList>().HasData
            (
                new PlayList { Id = 1, MusicProducerId = 1, Description = "Buenas rolas", AddedDate = DateTime.Now},
                new PlayList { Id = 2, MusicProducerId = 1, Description = "Eletronica", AddedDate = DateTime.Now },
                new PlayList { Id = 3, MusicProducerId = 2, Description = "Para estudiar", AddedDate = DateTime.Now },
                new PlayList { Id = 4, MusicProducerId = 2, Description = "Fiesta", AddedDate = DateTime.Now }
            );
            
            //Pay method

            builder.Entity<PayMethod>().HasData
            (
                new PayMethod { IdPayMethod = 1, Description = "metodo de pago blablabla", Name = "POS Visa"},
                new PayMethod { IdPayMethod = 2, Description = "metodo de pago 2", Name = "Efectivo" }
            );
            
            //Project

            builder.Entity<Project>().HasData
            (
                new Project { Id = 1, Description = "Cover Queen", Name = "Cover", AddedDate = DateTime.Now, PlayListId = 1},
                new Project { Id = 2, Description = "Billie Jeans", Name = "Michael Jackson", AddedDate = DateTime.Now, PlayListId = 1 },
                new Project { Id = 3, Description = "Levels remix", Name = "Avicii", AddedDate = DateTime.Now, PlayListId = 2 },
                new Project { Id = 4, Description = "Music relajante", Name = "Lofi music", AddedDate = DateTime.Now, PlayListId = 3 },
                new Project { Id = 5, Description = "Musica para fiestas", Name = "Salsa cubana", AddedDate = DateTime.Now, PlayListId = 1 },
                new Project { Id = 6, Description = "Recopilacion de merengue", Name = "Merengue", AddedDate = DateTime.Now, PlayListId = 1 }
            );

            //Constraints
           

            builder.UseSnakeCaseNamingConventions();
        }
    }
}
