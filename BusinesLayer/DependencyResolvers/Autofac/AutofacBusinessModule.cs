using Autofac;
using BusinesLayer.Abstract;
using BusinesLayer.Concrete;
using DataLayer.Abstract;
using DataLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ActivityManager>().As<IActivityService>();
            builder.RegisterType<EfActivityDal>().As<IActivityDal>();

            builder.RegisterType<WeatherManager>().As<IWeatherService>();


        }
    }
}
