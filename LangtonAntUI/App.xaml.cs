
using Microsoft.Extensions.DependencyInjection;

using System;

using System.Windows;


using System.Collections.Generic;


using LangtonAnt.DataModel;
using LangtonAnt.Interface;
using LangtonAnt.Rule;


namespace LangtonAntUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }


        private void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(GetGame())
                .AddSingleton<MainWindow>()
                ;
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();

            mainWindow.Show();
        }



        private IGame GetGame()
        {
            var ruleList = new List<IRule>()
                {
                new BlackRule(),
                new WhiteRule()
                }
                ;
            var game = new Game(new Gamer(ruleList));

            return game;
        }

    }
}
