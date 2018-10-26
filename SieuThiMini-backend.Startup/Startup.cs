using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SieuThiMini.AppService;
using SieuThiMini.DAL;

namespace SieuThiMini.Startup
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Console.WriteLine(Configuration["ConnectionStrings:DefaultConnection"]);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // For development
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddDbContext<SieuThiDbContext>(
                options => options.UseSqlServer
                        (
                            Configuration["ConnectionStrings:DefaultConnection"]
                        )
);

            services.AddService();

            Console.WriteLine(typeof(SieuThiMini.WebApi.SanPhamController).Assembly);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddApplicationPart(Assembly.Load("SieuThiMini.WebApi"))
            .AddControllersAsServices()
            ;

            File.WriteAllLines("services.txt",services.Select(s => s.ServiceType.FullName));
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();

            app.UseCors("CorsPolicy");
        }
    }
}
