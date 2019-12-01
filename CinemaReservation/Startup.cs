using AutoMapper;
using Cinema.BusinessLogic.Interfaces;
using Cinema.BusinessLogic.Services;
using Cinema.Persisted.Interfaces;
using Cinema.Persisted.Repositories;
using CinemaReservation.Mapping;
using CinemaReservation.Persisted.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CinemaReservation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReservationRecordService, ReservationRecordService>();
            services.AddScoped<IReservationTicketService, ReservationTicketService>();

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
            services.AddSingleton(mappingConfig.CreateMapper());

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ReservationContext>(options => options.UseSqlServer(connection));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "Cinema Reservation API", Version = "v1" }));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CinemaReservation API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/[controller]",
                    defaults: new { controller = "reservation" }
                );
            });

        }
    }
}
