using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Honors_2._0.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Honors_2._0.Domain.Services;
using Honors_2._0.Services;
using System;
using Honors_2._0.Domain.Repository;
using Honors_2._0.Persistance.Repositories;
using Microsoft.AspNetCore.Identity;
using Honors_2._0.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StackExchange.Redis;

namespace Honors_2._0
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
            services.AddControllers().AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

                services.AddDbContext<Honors20Context>(options =>
                    options.UseMySql(
                        Configuration.GetConnectionString("Default")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUsersRepository , UserRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketProductRepository, BasketProductRepository>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderProductsRepository, OrderProductRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewService, ReviewService>();

            var redisConfigurationOptions = ConfigurationOptions.Parse("localhost:6379");
            services.AddStackExchangeRedisCache(redisCacheConfig =>
            {
                redisCacheConfig.ConfigurationOptions = redisConfigurationOptions;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
