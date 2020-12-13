using crud_based_baltaio.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace crud_based_baltaio
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().AddMvcOptions(setupAction => setupAction.EnableEndpointRouting = false);

      // services.AddTransient<AppDataContext, AppDataContext>(); // ask for T, receives a new instance of T
      services.AddScoped<AppDataContext, AppDataContext>(); // ask for T, if exists an instance of T, then receives that, otherwise a new instance of T
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      app.UseMvc();
    }
  }
}
