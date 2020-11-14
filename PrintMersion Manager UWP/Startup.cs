using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Globals;
using PrintMersion.Core.Interfaces;
using PrintMersion.Infrastructure.ApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using PrintMersion.UWP.Controls;
using Windows.UI.Xaml.Data;
using PrintMersion.UWP.Extencions;
namespace PrintMersion.UWP
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static void Init()
        {
            

            var host = new HostBuilder()
                        .ConfigureServices((c, x) =>
                        {
                        // Configure our local services and access the host configuration
                        ConfigureServices(c, x);
                        }).
                        ConfigureLogging(l => l.AddConsole(o =>
                        {
                        //setup a console logger and disable colors since they don't have any colors in VS
                        o.DisableColors = true;
                        }))
                        .Build();

            //Save our service provider so we can use it later.
            ServiceProvider = host.Services;

          
        }

        static  void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            //ViewModels


           
            
            services.AddSingleton<IGlobal, GlobalData>();

            services.AddSingleton<IRepository<User>, ClientRepositoryBase<User>>();

            
        }

        public static T GetService<T>()
        {
          return  (T)Startup.ServiceProvider.GetService(typeof(T));
        }
    }


  
}
