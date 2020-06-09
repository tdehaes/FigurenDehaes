using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Fig.WPFapp.Viewmodel
{
    public class ViewModelLocator
    {
        private readonly IContainer _container;

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainViewModel>().SingleInstance();

            _container = builder.Build();
        }


        public MainViewModel Main => _container.Resolve<MainViewModel>();
    }
}
