using crud_based_baltaio.Data;
using crud_based_baltaio.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace crud_based_baltaio
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().AddMvcOptions(setupAction => setupAction.EnableEndpointRouting = false);

      services.AddResponseCompression();

      // services.AddTransient<AppDataContext, AppDataContext>(); // ask for T, receives a new instance of T
      services.AddScoped<AppDataContext, AppDataContext>(); // ask for T, if exists an instance of T, then receives that, otherwise a new instance of T
      services.AddTransient<ProductRepository, ProductRepository>();

      services.AddSwaggerGen(predicate =>
      {
        predicate.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "Crud based API",
          Version = "v1",
        });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      app.UseMvc();
      app.UseResponseCompression();

      app.UseSwagger();
      app.UseSwaggerUI(predicate =>
      {
        predicate.SwaggerEndpoint("/swagger/v1/swagger.json", "Crud based API - V1");
      });
    }
  }
}
