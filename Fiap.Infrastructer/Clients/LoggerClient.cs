using Fiap.Application.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Infrastructer.Clients
{
    public class LoggerClient : ILoggerClient
    {
        public void Log(string request)
        {
            var log = new LoggerConfiguration()
            .WriteTo.Logentries("d53d9bcd-f0da-4a61-bb75-28c91a5b16d2")
            .CreateLogger();
            //log sql
            log.Information($"request {request}");

        }
    }
}
