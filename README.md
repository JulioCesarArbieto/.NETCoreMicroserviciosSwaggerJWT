## Julio César Arbieto Chavez 👋 ##
Linkedin : https://www.linkedin.com/in/julio-césar-arbieto-chavez-867159155/


# .NETCoreMicroserviciosSwaggerJWT
En este proyecto se vera la creación de Microservicios  con .Net Core , Configuracion de Swagger, Creación de JWT para las identificaciones de los Microservices.   


* Este proyecto es una muestra de como Configuara el Swagger - el cual sirve para documentar las 
API REST Mediante un formato XML para ello debemos realizar serie de paso:*

- Paso 01 : Crear el proyecto Net core empty - Api
- Paso 02 : Instalar Nuget Swashbuckle.AspNetCore
- Paso 03 : Moodificar el metodo ConfigureServices del startup - agregar la seccion "Swagger Configure Developer".
       
       //en el ConfigureServices Swagger Configure Developer
       public void ConfigureServices(IServiceCollection services)
        {
            //Start Swagger Configure Developer
            ConfigureSagger(services);
            //End Swagger Configure Developer

            services.AddJwtCustomized();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ContextDatabase>(
             options =>
             {
                 options.UseSqlServer(Configuration["sql:cn"]);
             });

            services.AddScoped<IServiceAccount, ServiceAccount>();
            services.AddScoped<IRepositoryAccount, RepositoryAccount>();
            services.AddScoped<IContextDatabase, ContextDatabase>();
        }
- Paso 04 : crear el metodo ConfigureSagger en el startup, pasandole de parametro todo el services, este se encargar ade configurar todo lo necesario del swagger

        // crear metodo que sirve para configurar el swagger 
        private static void ConfigureSagger(IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Continer.Api.Manager.Acount Api", Version = "v1" });
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

- Paso 04 : Modificar el metodo Configure del startup, este se encargar ade configurar todo lo necesario del swagger "Swagger Configure Developer"

        //en el Configure agregar la seccion de Swagger Configure Developer
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Start Swagger Configure Developer
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Continer.Api.Manager.Acount V1");
            });
            //End Swagger Configure Developer

            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

- Paso 05 : Modificar el metodo Configure del startup, este se encargar ade configurar todo lo necesario del swagger "Swagger Configure Developer"
Para describir el controlador agegar summary,
Para decribir un metodo y poner un ejemplo del requet y response - asignar el summary y remarks

              namespace CONTINER.API.MANAGER.History.Controllers
              {
                  /// <summary>
                  /// Controlador de Historial de trasacciones
                  /// </summary>
                  [Route("api/[controller]")]
                  [ApiController]
                  public class HistoryController : ControllerBase
                  {
                      private readonly IServiceHistory _services;
                      public HistoryController(IServiceHistory services)
                      {
                          _services = services;
                      }
                      /// <summary>
                      /// This method - get all history transactions 
                      /// </summary>
                      /// <returns></returns>
                      [HttpGet]
                      public async Task<IActionResult> Get()
                      {
                          return Ok(await _services.GetAll());
                      }

                      /// <summary>
                      /// This method insert history transactions 
                      /// </summary>
                      /// <remarks>
                      /// 
                      /// Sample request:
                      /// 
                      ///     {
                      ///         "Id": 1,
                      ///         "IdTransaction": 1,
                      ///         "Amount": 200.10,
                      ///         "Type": "Deposit or withdrawal",
                      ///         "CreationDate": "dd/mm/yyyy hh:mm:ss",
                      ///         "AccountId": 1
                      ///     }
                      ///     
                      /// Sample response :
                      /// 
                      ///     Task IActionResult
                      /// 
                      /// </remarks>
                      /// <param name="request"></param>
                      /// <returns></returns>
                      [HttpPost()]
                      public async Task<IActionResult> Post([FromBody] HistoryTransaction request)
                      {
                          await _services.Add(request);
                          return Ok();
                      }
                      /// <summary>
                      /// This method call serveice - get acount for Id Account
                      /// </summary>
                      /// <remarks>
                      /// 
                      /// Sample request:
                      /// 
                      ///    GET api/History/{accountId}
                      ///     
                      /// Sample response :
                      /// 
                      ///     Task IActionResult
                      /// 
                      /// </remarks>
                      /// <param name="accountId"></param>
                      /// <returns></returns>
                      [HttpGet("{accountId}")]
                      public async Task<IActionResult> Get(int accountId)
                      {
                          var result = await _services.GetAll();
                          return Ok(result.Where(x => x.AccountId == accountId).ToList());
                      }
                  }
              }

