using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseShop.Core.Business.Repositories;
using CourseShop.Core.Business.Services;
using CourseShop.Core.DAL;
using CourseShop.Core.DAL.Repositories;
using CourseShop.Core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourseShop.Admin.Web
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
            services.AddDbContext<CourseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("CourseShop.Web"));
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CourseContext>()
                .AddDefaultTokenProviders();
            services.AddMvc(options => 
            {
                options.EnableEndpointRouting = false;
            });

            // Repositories
            services.AddTransient<ICourseRepository, CourseRepository>();

            // Services
            services.AddTransient<ICourseService, CourseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(name: "AccountArea", areaName: "Account", template: "{controller=Account}/{action=Index}/{id?}");
                routes.MapAreaRoute(name: "HomeArea", areaName: "Home", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
