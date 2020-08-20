using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ;
using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.History.RabbitMQ.EventHandlers;
using CONTINER.API.MANAGER.History.RabbitMQ.Events;
using CONTINER.API.MANAGER.History.Repository;
using CONTINER.API.MANAGER.History.Service;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace CONTINER.API.MANAGER.History
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
            //Start Swagger Configure Developer
            ConfigureSagger(services);
            //End Swagger Configure Developer

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IServiceHistory, ServiceHistory>();
            services.AddScoped<IRepositoryHistory, RepositoryHistory>();

            /*Start RabbitMQ*/
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<DepositEventHandler>();
            services.AddTransient<WithdrawalEventHandler>();
            services.AddTransient<IEventHandler<DepositCreatedEvent>, DepositEventHandler>();
            services.AddTransient<IEventHandler<WithdrawalCreatedEvent>, WithdrawalEventHandler>();
            /*End RabbitMQ*/
        }

        //This method create configuration Swagger
        private static void ConfigureSagger(IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Continer.Api.Manager.History Api", Version = "v1" });
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                config.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>()
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Start Swagger Configure Developer
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Continer.Api.Manager.History V1");
            });
            //End Swagger Configure Developer
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<DepositCreatedEvent, DepositEventHandler>();
            eventBus.Subscribe<WithdrawalCreatedEvent, WithdrawalEventHandler>();
        }
    }
}
