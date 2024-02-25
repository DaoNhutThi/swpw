using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Extensions.Logging;
using DataAccess.Data;
using DataAccess.DAO;
using Repository.IService;
using Repository.Service;
using BusinessObject.Models;

namespace ProjectSWP392
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureLogging(ILoggingBuilder logging)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/mylog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            logging.AddSerilog(Log.Logger);  // Use AddSerilog with the logger instance
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var mailsetting = Configuration.GetSection("MailSettings");
            services.Configure<EmailSetting>(mailsetting);
            services.AddTransient<EmailService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<AccountDAO>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<CartDAO>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<UserDAO>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<OrderDAO>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<OrderDetailDAO>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<CategoryDAO>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ProductDAO>();
            services.AddLogging(ConfigureLogging);
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
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
