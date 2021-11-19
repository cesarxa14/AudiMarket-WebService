using AudiMarket.Authorization.Handlers.Implementations;
using AudiMarket.Authorization.Handlers.Interfaces;
using AudiMarket.Authorization.Middleware;
using AudiMarket.Domain.Repositories;
using AudiMarket.Domain.Services;
using AudiMarket.Persistence.Contexts;
using AudiMarket.Persistence.Repositories;
using AudiMarket.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudiMarket
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("audimarket-api-in-memory");
            });

            services.AddScoped<IJwtHandler, JwtHandler>();


            services.AddScoped<IMusicProducerRepository, MusicProducerRepository>();
            services.AddScoped<IMusicProducerService, MusicProducerService>();

            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPublicationService, PublicationService>();

            

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AudiMarket", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AudiMarket v1"));
            }

            app.UseCors(builder => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin());

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
