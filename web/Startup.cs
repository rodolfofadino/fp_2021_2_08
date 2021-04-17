using Fiap.Core.Contexts;
using Fiap.Core.Services;
using Fiap.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDataProtection()
                .SetApplicationName("fiap")
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\Users\Rodolfof\source\repos\fiap2021\Fiap\web"));

            services.AddAuthentication("fiap")
            .AddCookie("fiap", o => {
                o.LoginPath = "/account/index";
                o.AccessDeniedPath = "/account/denied";
            });


            services.AddControllersWithViews();
            //.AddRazorRuntimeCompilation();

            //services.AddTransient<INoticiaService, NoticiaService>();
            //services.AddSingleton<INoticiaService, NoticiaService>();
            services.AddScoped<INoticiaService, NoticiaService>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=Fiap2021;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<DataContext>(option => option.UseSqlServer(connection));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMiddleware<MeuMiddleware>();
            app.UseMeuMiddlewareFiap();



            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseStaticFiles();
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