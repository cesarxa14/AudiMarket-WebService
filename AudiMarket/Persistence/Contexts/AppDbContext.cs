﻿using AudiMarket.Domain.Models;
using AudiMarket.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MusicProducer> MusicProducers { get; set; }

        public DbSet<Publication> Publications { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Constraints
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);

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
            
            //PlayList
            builder.Entity<Publication>().ToTable("PlayList");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Publication>().Property(p => p.AddedDate).IsRequired();
            builder.Entity<Publication>().Property(p => p.MusicProducerId).IsRequired().ValueGeneratedOnAdd();
            
            //Project
            builder.Entity<Publication>().ToTable("Project");
            builder.Entity<Publication>().HasKey(p => p.Id);
            builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Publication>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Publication>().Property(p => p.Description).IsRequired().HasMaxLength(100);
            builder.Entity<Publication>().Property(p => p.AddedDate).IsRequired();
            builder.Entity<Publication>().Property(p => p.PlayListId).IsRequired().ValueGeneratedOnAdd();
            




            //RelationShips
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<MusicProducer>().HasMany(p => p.Publications).WithOne(p => p.MusicProducer).HasForeignKey(p => p.MusicProducerId);

            // Seed Data
            builder.Entity<Category>().HasData
                (
                    new Category { Id = 100, Name = "Vegetales" },
                    new Category { Id = 101, Name = "Carnes" }
                );

            // Music Producer

            builder.Entity<MusicProducer>().HasData
                (
                    new MusicProducer { Id = 1, Firstname = "Cesar", Lastname = "Torres", Dni = "72289050", User = "cesarxa14", Password = "1234" }
                );

            //Publications

            builder.Entity<Publication>().HasData
                (
                    new Publication { Id = 1, Description = "Soy experto en electronica", PublicationDate = DateTime.Now, IdProject = 1, MusicProducerId = 1}
                );

            //PlayList

             builder.Entity<PlayList>().HasData
                (
                    new PlayList { Id = 1, Description = "PlayList One", AddedDate = DateTime.Now, MusicProducerId = 1}
                );

            //Project

            builder.Entity<Project>().HasData
                (
                    new Project { Id = 1, Description = "Name", Description = "Project One", AddedDate = DateTime.Now, PlayListId = 1}
                );



            //Constraints
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.UseSnakeCaseNamingConventions();
        }
    }
}
