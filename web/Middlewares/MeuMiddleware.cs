using Fiap.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Middlewares
{
    public class MeuMiddleware
    {
        private ILoggerClient _loggerClient;
        private RequestDelegate _next;

        public MeuMiddleware(RequestDelegate next, ILoggerClient loggerClient)
        {
            _loggerClient = loggerClient;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();

            var request = await FormatRequest(httpContext.Request);
            _loggerClient.Log(request);

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