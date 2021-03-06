﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ChemQuiz.API.Services;
using ChemQuiz.API.Services.Implementations;
using ChemQuiz.API.Models;

namespace ChemQuez.MobileAppService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration Configuration, IWebHostEnvironment Environment)
        {
            this.Configuration = Configuration;
            this.Environment = Environment;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsProduction() || Environment.IsStaging()) {
                services.AddDbContext<ChemQuiz.API.Models.Context.AppContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FabricioDocemaDBConnectionString")));
            }
            services.AddAuthentication(AzureADB2CDefaults.BearerAuthenticationScheme)
                .AddAzureADB2CBearer(options => Configuration.Bind("AzureAdB2C", options));
            services.AddControllers();
            services.AddScoped<IService<Avatar>, AvatarService>();
            services.AddScoped<IService<Category>, CategoryService>();
            services.AddScoped<IAppUserService, AppUserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}