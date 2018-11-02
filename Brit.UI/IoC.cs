using Autofac;
using Brit.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brit.UI
{
    internal class IoC 
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            var serviceAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.Contains("Brit.Service"));

            builder.RegisterAssemblyTypes(serviceAssembly)
                   .Where(x => x.GetInterfaces()[0].FullName.Contains("IFileInput"))
                   .As<IFileInput>()
                   .PropertiesAutowired();

            builder.RegisterAssemblyTypes(serviceAssembly)
                   .Where(x => x.GetInterfaces()[0].FullName.Contains("IFunction"))
                   .As<IFunction>()
                   .PropertiesAutowired();

            builder.RegisterAssemblyTypes(serviceAssembly)
                   .Where(x => x.GetInterfaces()[0].FullName.Contains("IExpressionBuilder"))
                   .As<IExpressionBuilder>()
                   .PropertiesAutowired();

            builder.RegisterAssemblyTypes(serviceAssembly)
                   .Where(x => x.GetInterfaces()[0].FullName.Contains("IStack"))
                   .As<IStack>()
                   .OnActivating(y => { (y.Instance as IStack).Expressions = new Dictionary<string, double>(); })
                   .PropertiesAutowired();

            builder.RegisterAssemblyTypes(serviceAssembly)
                   .Where(x => x.GetInterfaces()[0].FullName.Contains("ICalculator"))
                   .As<ICalculator>()
                   .OnActivating(y =>
                                 {
                                     var dependency = y.Context.Resolve<IEnumerable<IFunction>>();
                                     (y.Instance as ICalculator).FunctionList = dependency.ToList();
                                 })
                   .PropertiesAutowired();

            return builder.Build();

        }


    }
}