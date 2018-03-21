using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hearme_backend.repository;
using hearme_backend.repository.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace hearme_backend.webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ambiente = BuildWebHost(args);
            using(var escopo = ambiente.Services.CreateScope()){
                var servico = escopo.ServiceProvider;
                try{
                    var contexto = servico.GetRequiredService<HearMeContext>();
                    DatabaseStart.DbStart(contexto);
                    
                }
                catch(Exception ex){
                    var logger = servico.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex,"Ocorreu um problema enquanto os dados foram enviados");
                }
            }
            ambiente.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
