using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coderslinkapi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace coderslinkapi
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
                    services.AddCors(options => {
                options.AddPolicy("CodersLinkPolice",
                    builder => 
                    {
                        builder.WithOrigins("http://localhost:5000", "https://localhost:5001");
                        builder.AllowAnyHeader();
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                    });
                    
            });
            //i user memory database
            //reference: https://exceptionnotfound.net/ef-core-inmemory-asp-net-core-store-database/
              services.AddDbContext<CodersLinkDBContext>(options => options.UseInMemoryDatabase(databaseName: "CodersLink"));
            services.AddControllers();
            //add scope to my generic repository
           services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddSwaggerGen();
            
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
               // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API  CodersLink V1");
    });
  
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
      app.UseCors("CodersLinkPolice");
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
