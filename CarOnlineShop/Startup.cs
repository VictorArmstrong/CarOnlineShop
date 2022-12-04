using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CarOnlineShop.Models;
using CarOnlineShop.Data;
using CarOnlineShop.Data.Interfaces;
using CarOnlineShop.Data.Repositories;
using CarOnlineShop.Data.Models;
using System.IO;

namespace CarOnlineShop
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
       

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            //services.AddDbContext<CarOnlineShopContext>(options =>
            //        options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddDbContext<CarOnlineShopContext>(options => 
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICategoryRepository, category>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(c => ShoppingCart.GetCart(c));
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();           
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "categoryFilter",
                    template: "Products/{action}/{category?}",
                    defaults: new { Controller = "Products", action = "List"}
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.ExceedDb(app);
        }
    }
}
