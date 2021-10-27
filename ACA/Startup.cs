using BusinessLogicLayer.Data;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;

using DataAccessLayer.Services;
using InterfacesACA.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACA
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

            services.AddControllers();
            services.AddScoped<IBaseProductService<BaseProduct>,BaseProductService>();
            services.AddScoped<IBaseProductService<BaseProductClient>,BaseProductServiceBL>();
            services.AddScoped<IOrderService<Order>, OrderService>();
            services.AddScoped<IOrderService<OrderClient>, OrderServiceBL>();
            services.AddScoped<ICustomerService<Customers>,CustomerService>();
            services.AddScoped<ICustomerService<CustomerClient>, CustomerServiceBL>();
            services.AddScoped<ICRUD<Subcontractors, int>, SubcontractorService>();
            services.AddScoped<ICRUD<SubcontractorClient, int>, SubcontractorServiceBL>();
            services.AddScoped<IUserService<Users>, UserService>();
            services.AddScoped<IUserService<UserClient>, UserServiceBL>();
            services.AddScoped<ICRUD<OrderBaseProduct, int>, OrderBaseProductService>();
            services.AddScoped<ICRUD<OrderBaseProductClient, int>, OrderBaseProductServiceBL>();





            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ACA", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ACA v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
