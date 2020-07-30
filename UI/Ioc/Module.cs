using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DAL;
using UI.ViewModels;

namespace UI.Ioc
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MainWindow>().AsSelf();

            // view Models
            builder.RegisterType<MainPageViewModel>().AsSelf();

            // services
            builder.RegisterType<FlightsService>().As<IFlightsService>().SingleInstance();
        }

    }
}
