using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shoe.DAO;
using Shoe.Models.DBModels;
using Shoe.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoe
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
            services.AddTransient<IProductDAO, ProductDAOImp>();
            services.AddTransient<IProductService, ProductServiceImp>();
            services.AddTransient<IUserDAO, UserDAOImp>();
            services.AddTransient<IUserService, UserServiceImp>();
            services.AddTransient<ICartItemDAO, CartItemDAOImp>();
            services.AddTransient<ICartItemService, CartItemServiceImp>();

            services.AddDbContext<shoeContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("shoeContext"), new MySqlServerVersion(new Version(8, 0, 11)))
           );
            
            string distributed = Configuration["Distributed"];
            switch (distributed)
            {
                case "MEMORY":
                    services.AddDistributedMemoryCache();
                    services.AddSession(options =>
                    {
                        options.IdleTimeout = TimeSpan.FromSeconds(1000);
                        options.Cookie.HttpOnly = true;
                        options.Cookie.IsEssential = true;
                    });
                    break;

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            // session - uncomment this to work with Session
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
            });
        }
    }
}
