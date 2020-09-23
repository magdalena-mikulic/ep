using System;
using AutoMapper;
using EP.Magdalena_Sima.Database;
using EP.Magdalena_Sima.Services;
using EP.Magdalena_Sima.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EP.Magdalena_Sima
{
    public class Startup
    {
        private readonly IConfigurationSection _httpSettingsSection;


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _httpSettingsSection = configuration.GetSection(nameof(HttpSettings));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<HttpSettings>(_httpSettingsSection);

            services.AddTransient<IGenesisHttpService, GenesisHttpService>();

            services.AddDbContext<TerminDbContext>(options => options.UseInMemoryDatabase("TerminDb"));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}