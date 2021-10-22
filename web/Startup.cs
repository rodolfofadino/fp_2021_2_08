using Fiap.Persistence.Contexts;
using Fiap.Application.Services;
using Fiap.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Fiap.Application.Interfaces;
using Fiap.Infrastructer.Clients;
using Fiap.IoC;

namespace Fiap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

           
            DependencyContainer.RegisterServices(services);

           


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<MeuMiddleware>();
            app.UseMeuMiddlewareFiap();



            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();

            app.UseStaticFiles(new StaticFileOptions() { 
            
                OnPrepareResponse = ctx =>
                {
                    var duration = 60 * 60 * 24 * 200;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl]
                    = "public,max-age=" + duration;
                }
            
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

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


            //app.Use((context, next) =>
            //{
            //    context.Response.Headers.Add("X-Teste", "headerteste");
            //    return next();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await next.Invoke();
            //});

            //app.Map("/admin", mapApp =>
            //{
            //    mapApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Admin");
            //    });
            //});

            //app.MapWhen(context => context.Request.Query.ContainsKey("queryTeste"), mapApp =>
            //{
            //    mapApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Fiap!");
            //    });
            //});


            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Olá Fiap");
            //});
        }
    }
}