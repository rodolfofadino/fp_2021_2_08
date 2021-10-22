using Fiap.Application.Interfaces;
using Fiap.Application.Services;
using Fiap.Application.Validations;
using Fiap.Domain.Models;
using Fiap.Infrastructer.Clients;
using Fiap.Persistence.Contexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fiap.IoC
{
    public class DependencyContainer
    {

        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IValidator<Aluno>, AlunoValidation>();

            services.AddDataProtection()
               .SetApplicationName("fiap")
               .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\Users\Rodolfof\source\repos\fiap2021\Fiap\web"));

            services.AddAuthentication("fiap")
            .AddCookie("fiap", o => {
                o.LoginPath = "/account/index";
                o.AccessDeniedPath = "/account/denied";
            });

            services.AddMemoryCache();
            services.AddControllersWithViews().AddFluentValidation();

            services.AddScoped<INoticiaService, NoticiaService>();
            services.AddScoped<IRssClient, RssGloboClient>();
            services.AddScoped<ILoggerClient, LoggerClient>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=Fiap2021;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<DataContext>(option => option.UseSqlServer(connection));


            services.Configure<GzipCompressionProviderOptions>(o => o.Level = System.IO.Compression.CompressionLevel.Optimal);

            services.AddResponseCompression(o => {

                o.Providers.Add<GzipCompressionProvider>();
                //o.Providers.Add<BrotliCompressionProvider>();
            });
        }
    }
}
