using ClientBase.Core.Services;
using ClientBase.Infrastructure.Data;
using GoodsPlan.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientBase
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCoreEntities();

            services.AddDbContext<DBContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            services.AddRazorPages();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IPropertyTypeService, PropertyTypeService>();
            services.AddTransient<IIndustryService, IndustryService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICityService, CityService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
