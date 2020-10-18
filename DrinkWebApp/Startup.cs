using DrinkWebApp.Data.DbContexts;
using DrinkWebApp.Interfaces;
using DrinkWebApp.Mocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using DrinkWebApp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.SqlClient;
using DrinkWebApp.Services;
using DrinkWebApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DrinkWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection"),
                sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly("DrinkWebApp.Data");
                }));
            services.AddTransient<IDrinkRepository, DrinkRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
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
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{category?}");
                // Note : Search on how to use multiple endpoints and make sure it works
                //endpoints.MapControllerRoute(
                //    name: "categoryfilter",
                //    pattern: "Drink/{action}/{category?}",
                //    defaults: new { Controller = "Drink", action = "Index" });
            });

            DbInitializer.Seed(app);
        }
    }
}