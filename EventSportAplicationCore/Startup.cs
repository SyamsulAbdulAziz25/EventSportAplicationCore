using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sport.DataAccesLayer;
using Sport.BussinesLogicLayer;
using Sport.Core.Contracts;
using Sport.DataAccesLayer.Implement;
using Sport.Core;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Sport.Core.Output;
using EventSportAplicationCore.Models;

namespace EventSportAplicationCore
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
            services.AddControllersWithViews();
            services.AddDbContext<SportEventContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"))
                );
            services.AddTransient<ISportEventBussinesLayer, SportEventBussinesLayer>();
            services.AddTransient<ISportEventRepository, SportEventRepository>();
            services.AddTransient(typeof(IRepository<Event>), typeof(Repository<Event>));

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
        }
        /// <summary>
        /// configure create for mapper
        /// </summary>
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Add as many of these lines as you need to map your objects
                CreateMap<SportEventOutput, Event>();
                CreateMap<Event, SportEventOutput>();
                CreateMap<ViewModelEvent,Event>();
                
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/SportEvent/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SportEvent}/{action=Index}/{id?}");
            });
        }
    }
}
