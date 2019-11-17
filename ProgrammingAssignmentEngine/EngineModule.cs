﻿using Ninject.Modules;
using Ninject.Extensions.Conventions;
using System;
using System.Collections.Generic;

namespace ProgrammingAssignmentEngine
{
    public class EngineModule : NinjectModule
    {
        private static IEnumerable<Type> _excludedTypes = new List<Type>()
        { };
        public override void Load()
        {
            this.Bind(syntax => syntax
            .FromThisAssembly()
            .SelectAllClasses()
            .Excluding(_excludedTypes)
            .BindDefaultInterface()
            .Configure(config => config.InThreadScope()));
        }
    }
}
