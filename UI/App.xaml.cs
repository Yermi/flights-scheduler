using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI.Ioc;
using UI.ViewModels;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();
            builder.RegisterModule<MainModule>();
            
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var window = new MainWindow();
                window.DataContext = scope.Resolve<MainPageViewModel>();
                window.Show();
            }

            //var mainWindow = new MainWindow();
            //var mwvm = new MainPageViewModel();
            //mainWindow.DataContext = mwvm;
            //mainWindow.Show();
        }
    }
}
