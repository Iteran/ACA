using ACA.Token;
using BusinessLogicLayer.Data;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;

using DataAccessLayer.Services;
using InterfacesACA.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            services.AddScoped<IManufacturingService<Manufacturing>, ManufacturingService>();
            services.AddScoped<IManufacturingService<ManufacturingClient>, ManufacturingServiceBL>();
            services.AddScoped<ICRUD<ContractManufacturingClient, int>, ContractManufacturingServiceBL>();
            services.AddScoped<TokenManager>();
            services.AddScoped<ICRUD<ContractManufacturing, int>, ContractManufacturingService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ACA", Version = "v1" });
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "bearerAuth"
                                }
                            },
                            new string[] {}
                    }
                });
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
                    options.AddPolicy("user", policy => policy.RequireRole("user", "admin"));
                });
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new()
                   {
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.SecretKey)),
                       ValidateIssuer = true,
                       ValidIssuer = TokenManager.Issuer,
                       ValidateAudience = true,
                       ValidAudience = TokenManager.Audience
                   };
               });

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
