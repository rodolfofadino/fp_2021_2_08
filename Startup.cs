using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    //,
                    //defaults:new { Controller="Home", Action="Index" }
                    // /, /home/sobre, /eventos/palestrantes
                    );
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Boa tarde :) ");
            //});
        }
    }
}