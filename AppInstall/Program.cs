using Apps.DataDb.Context;
using Apps.DataDb.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppInstall
{
    static class Program
    {
        private static Container container;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            //var serviceProvider = new ServiceCollection()
            //    .AddSingleton<IConfiguration, config>()
            //    .BuildServiceProvider();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            //            Application.Run(new FrmPrincipal());
            Application.Run(container.GetInstance<FrmPrincipal>());
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new Container();

            //var ctx = new AppDbContext();

            //var repoApp = new AppsRepository(ctx);

            // Register your types, for instance:
            //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Singleton);
            //container.Register<IUserContext, WinFormsUserContext>();
            //container.Register<Form1>();

            container.Register<AppDbContext>(Lifestyle.Singleton);
            container.Register<AppsRepository>();

            // Optionally verify the container.
            container.Verify();
        }
    }
}
