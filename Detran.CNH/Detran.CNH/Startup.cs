using Detran.CNH.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using AutoMapper; 
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Detran.CNH
{
    public class Startup
    {
        public Startup (IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile(Path.Combine(env.ContentRootPath, $"appsettings.json"), optional: true)
                            .AddJsonFile(Path.Combine(env.ContentRootPath, $"appsettings.{env.EnvironmentName}.json"), optional: true);

            builder.AddEnvironmentVariables(); 
            _configuration = builder.Build();
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add AutoMapper
            services.AddAutoMapper(Assembly.Load("Detran.CNH.Application"));

            // Add dependency injection
            services.AddDependencyInjection(_configuration);

            // Add controllers
            services.AddControllers();

            // Add Swagger Generator with security settings
            services.AddSwaggerGen(setup => {
                setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Input the JWT like: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            // Enable Bearer Token authentication
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Config")["SecKey"]));
            services.AddAuthentication(options =>  {
                options.DefaultAuthenticateScheme = options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = key,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(config => { config.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader(); });

           // ConfigureConfiguration(env);

            // Use Swagger & UI at the root URL route
            app.UseSwagger();
            app.UseSwaggerUI(setup => { 
                setup.SwaggerEndpoint("swagger/v1/swagger.json", "API Name");
                setup.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            // Use authorization and authentication
            app.UseAuthentication();
            app.UseAuthorization();
             
            app.UseEndpoints(config =>
            {
                config.MapControllers();
            }); 
        }

        
    }
}
