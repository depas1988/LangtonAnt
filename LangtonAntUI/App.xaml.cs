using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace LangtonAntUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
        }


        private void ConfigureServices(IServiceCollection services)
        {
            //services
            //    .AddSingleton(_runConfiguration.Channels)
            //    .AddSingleton(BusinessFileValidation())
            //    .AddSingleton(BusinessFileP360DataComparer())
            //    .AddSingleton(ReportBuilderSetUp())
            //    .AddSingleton(P360ServiceApiSetUp())
            //    .AddSingleton<Flow>()
            //    .AddSingleton<MainWindow>()
            //    ;
        }

        //private IDataExtractor<BusinessInput> BusinessFileValidation()
        //{
        //    var processChainFactory = new ProcessChainFactory();
        //    var iCheckerChain = processChainFactory.CreateChainImportFileChecks();
        //    var fileValidator = new BusinessValidator(iCheckerChain, _runConfiguration.FileMtbDictionary);


        //    var businessDataManipulator = new BusinessDataManipulator();
        //    var fileReader = new BusinessFileInputReader(businessDataManipulator);
        //    return new DataExtractor<BusinessInput>(fileValidator, fileReader);
        //}
    }
}
