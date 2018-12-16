using System;
using Around.Core.Interfaces;
using Around.Core.Services;
using Around.DataAccess.SqlServer;
using Around.DataAccess.SqlServer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Around.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<DronesharingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IChequeRepository, ChequeRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ICopterRepository, CoptersRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IRentRepository, RentRepository>();
            services.AddTransient<IReportRenderer, ReportRenderer>();
            services.AddTransient<IMailBox, MailBox>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Around API", Version = "v1" });
            });

            services.AddCors();
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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Around V1");
            });

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
