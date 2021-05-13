using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaPlace.Models;
using PizzaPlace.Repositories;
using PizzaPlace.Repositories.Interfaces;
using PizzaPlace.Services;
using PizzaPlace.Services.Interfaces;
using System;

namespace PizzaPlace
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
            services.AddRazorPages();

            services.AddDbContext<PizzaPlaceDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("PizzaPlaceDb")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<PizzaPlaceDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => {
                options.ExpireTimeSpan = TimeSpan.FromDays(int.Parse(Configuration["CookieExpirationPeriod"]));
                options.LoginPath = "/admin/login";
            });
            //(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
            //    options =>
            //    {
            //        options.ExpireTimeSpan = TimeSpan.FromDays(int.Parse(Configuration["CookieExpirationPeriod"]));
            //        options.LoginPath = "/Auth/SignIn";
            //        options.AccessDeniedPath = "/Auth/AccessDenied";
            //        //options.SlidingExpiration = false; -- da se iskluci i pokraj aktivnost

            //    }
            //    );

            //services
            services.AddTransient<IOffersService, OffersService>();
            services.AddTransient<IMenuItemsService, MenuItemsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<ISubscriptionsService, SubscriptionsService>();


            //repositories
            services.AddTransient<IOffersRepository, OffersRepository>();
            services.AddTransient<IMenuItemsRepositorty, MenuItemsRepositorty>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<ISubscriptionsRepository, SubscriptionsRepository>();
                      
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
