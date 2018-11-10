using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.API.Data;
using Event.API.Domain;
using Event.API.Interfaces;
using Event.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Event.API
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
            services.AddDbContext<EventDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddMvc();
            services.AddCors(o => o.AddPolicy("WorkShopPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            }));
            services.AddScoped(typeof(IWorkShopService), typeof(WorkShopService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EventDbContext eventDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("WorkShopPolicy");
            eventDbContext.Database.Migrate();
            eventDbContext.EnsureSeedDataForContext();
            app.UseMvc();
        }
    }
}
