using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PlannR.API.Middleware;
using PlannR.API.Services;
using PlannR.Application;
using PlannR.Application.Contracts.Identity;
using PlannR.Identity;
using PlannR.Persistence;
using System;
using System.Collections.Generic;

namespace PlannR.API
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

            services.AddApplicationServices()
                //.AddInfrastructureServices()
                .AddPersistenceServices(Configuration)
                .AddIdentityServices(Configuration);

            services.AddHttpContextAccessor();

            services.AddScoped<ILoggedInService, LoggedInService>();
            services.AddScoped(typeof(IAuthorisationService<>), typeof(AuthorisationService<>));

            services.AddControllers();

            

            services.AddCors(options =>
            {
                options.AddPolicy("Production", builder => builder
                .WithOrigins("https://plannr.azurewebsites.net",
                "https://owensteele.github.io",
                "https://plannr-api.azurewebsites.net")
                .AllowAnyMethod().AllowAnyHeader());

                options.AddPolicy("Development", builder => builder
                .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PlannR.API",
                    Version = "v1",
                    Description = "Public Web API for PlannR",
                    Contact = new OpenApiContact
                    {
                        Name = "Owen Steele",
                        Email = "contact@owensteele.co.uk",
                        Url = new Uri("https://owensteele.co.uk"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors("Development");
            }
            else
            {
                app.UseCors("Production");
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UsePlannrMiddleware();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlannR.API v1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
