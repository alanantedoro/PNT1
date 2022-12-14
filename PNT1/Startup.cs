using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PNT1.Context;
using Newtonsoft.Json;
using PNT1.Models.Models;
using PNT1.Models;
using Microsoft.AspNetCore.Identity;

namespace PNT1
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
            services.AddDbContext<PNT1DatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionString:PNT1DBConnection"]));

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<PNT1DatabaseContext>();

            services.Configure<CookiePolicyOptions>(options => 
            {
                // This lambda determines whether user consent for nonessential cookies is needed for a given request.                  
                options.CheckConsentNeeded = context => true; 
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            


            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)                     
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllersWithViews();
            services.AddScoped<IItemRepositorio, ItemRepositorio>();
            services.AddScoped<Carrito>(c => Carrito.getCarrito(c));
            services.AddScoped<IVentaRepositorio, VentaRepositorio>();

            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddRazorPages();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Items}/{action=List}/{id?}");

                endpoints.MapRazorPages();
            });
            

        }
    }
}
