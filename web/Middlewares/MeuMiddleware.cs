using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Middlewares
{
    public class MeuMiddleware
    {
        private RequestDelegate _next;

        public MeuMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            
            var request = await FormatRequest(httpContext.Request);
            var log = new LoggerConfiguration()
            .WriteTo.Logentries("d53d9bcd-f0da-4a61-bb75-28c91a5b16d2")
            .CreateLogger();
            //log sql
            log.Information($"request {request}");

            httpContext.Request.Body.Position = 0;
            
            await _next(httpContext);
            ///depois
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            
            //request.Body = body;
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);

            var messageObjToLog = new { scheme = request.Scheme, host = request.Host, path = request.Path, queryString = request.Query, requestBody = bodyAsText };

            return JsonConvert.SerializeObject(messageObjToLog);
        }
    }
}