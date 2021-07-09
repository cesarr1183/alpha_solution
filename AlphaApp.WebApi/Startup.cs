using AlphaApp.DataClasses;
using AlphaApp.Services;
using AlphaApp.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlphaApp.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddTransient<IService<Product>, ProductService>();

            services.AddSwaggerGen(swagger => {
                swagger.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\AlphaApp.WebApi.xml");
                swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() {
                    Version = "v1",
                    Title = "AlphaApp - WebApi",
                    Description = "Designing a WebApi to handle a single service."
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
